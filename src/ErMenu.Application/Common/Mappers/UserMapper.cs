using ErMenu.Application.Common.DTOs.Users;
using ErMenu.Domain.Aggregates.Users.Entities;

namespace ErMenu.Application.Common.Mappers;


public static class UserMapper
{


    public static UserProfileDto ToProfileDto(User user)
    {
        return new UserProfileDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber ?? ""
        };
    }


    
     

    public static ActorDto ToActorDto(User user)
    {
        return new ActorDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName, 
        };
    }



    
}