using Apwd.GestorLine.Services.Mapping.v1.System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Apwd.GestorLine.Ioc.Extensions.v1;

public static class MappingExtension
{
    public static IServiceCollection AddMappingContext(this IServiceCollection services)
    {
        MapperConfiguration mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new UserProfile());
            cfg.AddProfile(new FinancialProfile());
        });
        services.AddSingleton(c => mapper.CreateMapper());

        return services;
    }
}
