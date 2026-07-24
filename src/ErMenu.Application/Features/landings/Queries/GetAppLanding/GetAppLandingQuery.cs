using ErMenu.Application.Common.Models.BaseResult;
using ErMenu.Application.Features.landings.Queries.GetAppLanding.DTOs;
using MediatR;

namespace ErMenu.Application.Features.landings.Queries.GetAppLanding;

public record GetAppLandingQuery : IRequest<Result<LandingDto>>;
