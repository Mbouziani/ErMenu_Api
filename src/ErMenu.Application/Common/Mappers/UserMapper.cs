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
            FullName = user.FullName, 
        };
    }


    
     

    public static ActorDto ToActorDto(User user)
    {
        return new ActorDto
        {
            Id = user.Id,
            FullName = user.FullName, 
        };
    }



    
}