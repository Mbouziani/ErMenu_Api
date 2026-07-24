using ErMenu.Application.Common.Interfaces.Security;
using ErMenu.Domain.Aggregates.Users.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ErMenu.Infrastructure.Services.Security;

public class CurrentActor(IHttpContextAccessor accessor) : ICurrentActor
{
    private ClaimsPrincipal? User => accessor.HttpContext?.User;

    public int UserId =>
        int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id)
            ? id
            : throw UserExceptions.MissingUserIdClaim();

    public int BranchId =>
        int.Parse(User?.FindFirst("BranchId")?.Value
            ?? throw UserExceptions.MissingBranchIdClaim());

    public string? Email =>
        User?.FindFirst(ClaimTypes.Email)?.Value;

    public bool IsAuthenticated =>
        User?.Identity?.IsAuthenticated ?? false;


}