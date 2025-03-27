using Apwd.GestorLine.MongoDb;
using Apwd.GestorLine.MongoDb.Contexts.v1;
using Apwd.GestorLine.MongoDb.Contracts.v1;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;
using Apwd.GestorLine.MongoDb.Repository.v1.System;
using Microsoft.Extensions.DependencyInjection;

namespace Apwd.GestorLine.Ioc.Extensions.v1
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositoryContext(this IServiceCollection services)
        {
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
