using Apwd.GestorLine.Domain.Entities.v1.System;
using Apwd.GestorLine.Domain.Models.v1.System;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;

namespace Apwd.GestorLine.MongoDb;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetLoginAsync(UserLoginModel obj);
}
