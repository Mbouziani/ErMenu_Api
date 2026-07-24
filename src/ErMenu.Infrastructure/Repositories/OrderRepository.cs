using ErMenu.Domain.Aggregates.Orders.Entities;
using ErMenu.Domain.Aggregates.Orders.Repositories;
using ErMenu.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ErMenu.Infrastructure.Repositories;

internal class OrderRepository(AppDbContext context) : IOrderRepository
{ 
    public async Task<string> InsertUsingXmlAsync(Sales_SalesInvoiceMaster order, CancellationToken cancellationToken = default)
    {
        var xml = ConvertObjectToXMLString(order.SaleDatails);

        var connection = context.Database.GetDbConnection();

        await context.Database.OpenConnectionAsync(cancellationToken); 

        var command = connection.CreateCommand();

        command.CommandText = "Sales_SalesInvoiceMaster_SP";
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(new SqlParameter("@xmlData", SqlDbType.Xml) { Value = xml });
        command.Parameters.Add(new SqlParameter("@InvoiceDateTime", SqlDbType.DateTime2) { Value = order.InvoiceDateTime });

        command.Parameters.Add(new SqlParameter("@InvoiceID", order.InvoiceID));
        command.Parameters.Add(new SqlParameter("@PosID", order.PosID));
        command.Parameters.Add(new SqlParameter("@CurentSesionID", order.CurentSesionID));
        command.Parameters.Add(new SqlParameter("@MethodeID", order.MethodeID));
        command.Parameters.Add(new SqlParameter("@TypeAccount", order.TypeAccount));
        command.Parameters.Add(new SqlParameter("@InsuranceAmmount", order.InsuranceAmmount));
        command.Parameters.Add(new SqlParameter("@AddressCustomer", order.AddressCustomer));
        command.Parameters.Add(new SqlParameter("@CustomerName", order.CustomerName));
        command.Parameters.Add(new SqlParameter("@CustomerMobile", order.CustomerMobile));
        command.Parameters.Add(new SqlParameter("@CustomerID", order.CustomerID));
        command.Parameters.Add(new SqlParameter("@CostCenterID", order.CostCenterID));
        command.Parameters.Add(new SqlParameter("@SellerID", order.SellerID));
        command.Parameters.Add(new SqlParameter("@StoreID", order.StoreID));
        command.Parameters.Add(new SqlParameter("@PaidAmount", order.PaidAmount));

        command.Parameters.Add(new SqlParameter("@DelegateID", order.DelegateID));
        command.Parameters.Add(new SqlParameter("@Notes", order.Notes));
        command.Parameters.Add(new SqlParameter("@VATID", order.VATID));
        command.Parameters.Add(new SqlParameter("@DocumentID", order.DocumentID));
        command.Parameters.Add(new SqlParameter("@CurencyID", order.CurencyID));

        command.Parameters.Add(new SqlParameter("@InvoiceDate", order.InvoiceDate));
        command.Parameters.Add(new SqlParameter("@LastPrintDate", order.LastPrintDate));
        command.Parameters.Add(new SqlParameter("@PrintCount", order.PrintCount));



        command.Parameters.Add(new SqlParameter("@CheckSpendDate", order.CheckSpendDate));
        command.Parameters.Add(new SqlParameter("@WarningDate", order.WarningDate));

        command.Parameters.Add(new SqlParameter("@NetProcessID", order.NetProcessID));
        command.Parameters.Add(new SqlParameter("@CheckID", order.CheckID));

        command.Parameters.Add(new SqlParameter("@FromCashierScreen", order.FromCashierScreen));
        command.Parameters.Add(new SqlParameter("@CloseCashier", order.CloseCashier));
        command.Parameters.Add(new SqlParameter("@CloseCashierDate", order.CloseCashierDate));

        command.Parameters.Add(new SqlParameter("@DailyID", order.DailyID));
        command.Parameters.Add(new SqlParameter("@OrderType", order.OrderType));
        command.Parameters.Add(new SqlParameter("@SectionID", order.SectionID));
        command.Parameters.Add(new SqlParameter("@TableID", order.TableID));
        command.Parameters.Add(new SqlParameter("@NeedReview", order.NeedReview));
        command.Parameters.Add(new SqlParameter("@ReviewType", order.ReviewType));
        command.Parameters.Add(new SqlParameter("@IsSendReview", order.IsSendReview));
        command.Parameters.Add(new SqlParameter("@WorkDetails", order.WorkDetails));
        command.Parameters.Add(new SqlParameter("@Status", order.Status));

        command.Parameters.Add(new SqlParameter("@DebitAccount", order.DebitAccount));
        command.Parameters.Add(new SqlParameter("@CreditAccount", order.CreditAccount));
        command.Parameters.Add(new SqlParameter("@DiscountDebitAccount", order.DiscountDebitAccount));
        command.Parameters.Add(new SqlParameter("@CheckAccount", order.CheckAccount));
        command.Parameters.Add(new SqlParameter("@NetAmount", order.NetAmount));
        command.Parameters.Add(new SqlParameter("@NetAccount", order.NetAccount));
        command.Parameters.Add(new SqlParameter("@AdditionalAccount", order.AdditionalAccount));

        command.Parameters.Add(new SqlParameter("@UserID", order.UserID));
        command.Parameters.Add(new SqlParameter("@RegDate", order.RegDate));
        command.Parameters.Add(new SqlParameter("@RegTime", order.RegTime));
        command.Parameters.Add(new SqlParameter("@RegTimeHour", order.RegTimeHour));
        command.Parameters.Add(new SqlParameter("@RegTimeMintes", order.RegTimeMintes));
        command.Parameters.Add(new SqlParameter("@EditUserID", order.EditUserID));
        command.Parameters.Add(new SqlParameter("@EditTime", order.EditTime));
        command.Parameters.Add(new SqlParameter("@EditDate", order.EditDate));
        command.Parameters.Add(new SqlParameter("@ComputerInfo", order.ComputerInfo));
        command.Parameters.Add(new SqlParameter("@EditComputerInfo", order.EditComputerInfo));
        command.Parameters.Add(new SqlParameter("@Cancel", order.Cancel));

        command.Parameters.Add(new SqlParameter("@EmployeeID", order.EmployeeID));
        command.Parameters.Add(new SqlParameter("@PateintID", order.PateintID));
        command.Parameters.Add(new SqlParameter("@TempInvoiceID", order.TempInvoiceID));
        command.Parameters.Add(new SqlParameter("@EnduranceRatio", order.EnduranceRatio));
        command.Parameters.Add(new SqlParameter("@RegistrationNo", order.RegistrationNo));
        command.Parameters.Add(new SqlParameter("@NetBalance", order.NetBalance));
        command.Parameters.Add(new SqlParameter("@NetType", order.NetType));
        command.Parameters.Add(new SqlParameter("@InvoiceTotal", order.InvoiceTotal));
        command.Parameters.Add(new SqlParameter("@AdditionaAmountTotal", order.AdditionaAmountTotal));
        command.Parameters.Add(new SqlParameter("@DiscountOnTotal", order.DiscountOnTotal));
        command.Parameters.Add(new SqlParameter("@OperationTypeName", order.OperationTypeName));
        command.Parameters.Add(new SqlParameter("@BranchID", order.BranchID));
        command.Parameters.Add(new SqlParameter("@FacilityID", order.FacilityID));
        command.Parameters.Add(new SqlParameter("@RemaindAmount", order.RemaindAmount));



        var productId = new SqlParameter("@ProductId", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };

        var pDailyId = new SqlParameter("@PDailyID", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };

        command.Parameters.Add(productId);
        command.Parameters.Add(pDailyId);

        command.Parameters.Add(new SqlParameter("@CMDTYPE", 1));

        await command.ExecuteNonQueryAsync(cancellationToken);

        await context.Database.CloseConnectionAsync();


        return $"{productId.Value}-{pDailyId.Value}";
    }

    static string ConvertObjectToXMLString(object classObject)
    {
        var serializer = new XmlSerializer(classObject.GetType());

        var settings = new XmlWriterSettings
        {
            OmitXmlDeclaration = true,
            Encoding = Encoding.UTF8
        };

        using var stringWriter = new StringWriter();
        using var xmlWriter = XmlWriter.Create(stringWriter, settings);

        serializer.Serialize(xmlWriter, classObject);

        return stringWriter.ToString();
    }

 } 