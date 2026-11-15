using ErMenu.Application.Common.Behaviors;
using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Application.Common.Models.BaseResult;
using ErMenu.Domain.Aggregates.Orders.Entities;
using ErMenu.Domain.Aggregates.Orders.Exceptions;
using ErMenu.Domain.Aggregates.Orders.Repositories;
using ErMenu.Domain.Aggregates.Users.Entities;
using ErMenu.Domain.Aggregates.Users.Exceptions;
using ErMenu.Domain.Aggregates.Users.Repositories;
using MediatR;

namespace ErMenu.Application.Features.Orders.Commands.CreateOrder;

internal class CreateOrderCommandHandler(
    ICurrentActor currentActor,
    IUserRepository userRepository,
    IOrderRepository orderRepository)
    : IRequestHandler<CreateOrderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {

        int? sessionId = await userRepository.GetCurrentSessionIdAsync(currentActor.UserId, cancellationToken);

        if(sessionId == null)
        {
            var maxSessionId = await userRepository.GetMaxSessionIdAsync(currentActor.BranchId, cancellationToken) ?? 0;

            var session = UserSession.Create(
                currentActor.UserId,
                currentActor.BranchId,
                maxSessionId + 1
            );

            var result = await userRepository.CreateNewSessionAsync(session, cancellationToken);

            if(result == 0)
                throw UserExceptions.ProblemOccurredWhileInsertingUserSession();
            

            sessionId = await userRepository.GetCurrentSessionIdAsync(currentActor.UserId, cancellationToken)
                ?? throw UserExceptions.ProblemOccurredWhileInsertingUserSession();

        }






        List<Sales_SalesInvoiceDetails> saleDetails = [.. request.Order.Lines.Select(line =>
            Sales_SalesInvoiceDetails.Create(
                itemId: line.ProductId,
                sizeId: line.SizeId,
                branchId: currentActor.BranchId,
                barcode: line.Barecode,
                additionalInfo: line.AdditionalInfo,
                quantity: line.Quantity, 

                salePrice: line.OneUnitAmountBeforeVat,
                total: line.TotalAmountBeforeVat,
                discount: line.DiscountAmount,
                net: line.TotalAmount,
                additionalValue: line.TaxAmount
            ))];



        var order = Sales_SalesInvoiceMaster.Create(
            userId: currentActor.UserId,
            sessionId: sessionId ?? throw UserExceptions.ProblemOccurredWhileInsertingUserSession(),

            branchId: currentActor.BranchId,
            methodeId: request.Order.MethodId,

            saleDetails: saleDetails,


            netBalance: request.Order.TotalAmount,
            netAmount: request.Order.CardPaymentAmount,
            descount: request.Order.DiscountAmount,
            additionaAmountTotal: request.Order.TaxAmount,
            invoiceTotal: request.Order.TotalAmountBeforeVat


            );


        var invoiceOrderIds = await orderRepository.InsertUsingXmlAsync(order, cancellationToken)
            ?? throw OrderExceptions.FailedToCreateOrder();


        return Result<string>.Success(invoiceOrderIds);
    }
}