using Apwd.GestorLine.Domain.Entities.v1.System;
using Apwd.GestorLine.Domain.Models.v1.System;
using AutoMapper;

namespace Apwd.GestorLine.Services.Mapping.v1.System;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, AddUserModel>().ReverseMap();
    }
}
