using ErMenu.Application.Common.DTOs.Users;

namespace ErMenu.Application.Features.landings.Queries.GetAppLanding.DTOs;

public class LandingDto
{
    public int FractionDigits { get; set; } = 2;
    public int TaxRate { get; set; } = 15; 


    public List<CategoryDto> Categories { get; set; } = [];

 
    public ActorDto User { get; init; } = null!;
}
