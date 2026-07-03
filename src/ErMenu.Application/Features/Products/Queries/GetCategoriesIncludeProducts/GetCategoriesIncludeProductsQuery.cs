using ErMenu.Application.Common.Models.BaseResult;
using MediatR;

namespace ErMenu.Application.Features.Products.Queries.GetCategoriesIncludeProducts;

public record GetCategoriesIncludeProductsQuery : IRequest<Result<List<CategoryDto>>>;
