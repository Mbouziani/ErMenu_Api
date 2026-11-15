using ErMenu.Application.Common.Behaviors;
using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Application.Common.Mappers;
using ErMenu.Application.Common.Models.BaseResult;
using ErMenu.Application.Features.landings.Queries.GetAppLanding.DTOs;
using ErMenu.Domain.Aggregates.Products.Repositories;
using ErMenu.Domain.Aggregates.Users.Exceptions;
using ErMenu.Domain.Aggregates.Users.Repositories;
using MediatR;

namespace ErMenu.Application.Features.landings.Queries.GetAppLanding;

internal class GetAppLandingQueryHandler(
    ICurrentActor currentActor,
    IUserRepository userRepository,
    IProductRepository productRepository)
    : IRequestHandler<GetAppLandingQuery, Result<LandingDto>>
{
    public async Task<Result<LandingDto>> Handle(
        GetAppLandingQuery request,
        CancellationToken cancellationToken)
    {

        var user = await userRepository.GetByIdAsync(currentActor.UserId, cancellationToken)
            ?? throw UserExceptions.AccountUnavailable();

        var offers = await productRepository.GetProductOffersAsync(cancellationToken);
         
        var categories = await productRepository.GetFullProductsNavigationAsync(cancellationToken);

        List<CategoryDto> categoriesDtos = [.. categories.Select(c => CategoryDto.FromEntity(c, offers))];

        foreach (var catDto in categoriesDtos)
        {
            if (catDto?.Additionals?.Count == 0)
            {
                catDto.Additionals = [];
                foreach (var other in categoriesDtos)
                {
                    if (catDto.Id != other.Id && other.Additionals?.Count > 0)
                    {
                        catDto.Additionals.AddRange(other.Additionals);
                    }
                }
            }

        }
         
        var landingDto = new LandingDto
        {
            FractionDigits = 2,  
            TaxRate = 15,  
            Categories = categoriesDtos,
            User = UserMapper.ToActorDto(user),
        };

        return Result<LandingDto>.Success(landingDto);
    } 
}