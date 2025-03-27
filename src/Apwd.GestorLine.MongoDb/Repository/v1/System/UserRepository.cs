using Apwd.GestorLine.Domain.Entities.v1.System;
using Apwd.GestorLine.Domain.Models.v1.System;
using Apwd.GestorLine.MongoDb.Contracts.v1;
using MongoDB.Driver;

namespace Apwd.GestorLine.MongoDb.Repository.v1.System
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbContext context) : base(context)
        {
        }

        public async Task<User> GetLoginAsync(UserLoginModel filter)
        {
            var obj = await DbSet.FindAsync(Builders<User>.Filter
                   .Where(f => f.UserName == filter.UserName && f.PasswordHash == filter.UserCode));

            return obj.FirstOrDefault();
        }
    }
}
