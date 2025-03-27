using Apwd.GestorLine.Domain.Models.v1.System;

namespace Apwd.GestorLine.Services.Contracts.v1.System
{
    public interface IUserService
    {
        Task<UserModel> GetLogin(UserLoginModel obj);
        Task<UserModel> Add(AddUserModel obj);
    }
}
