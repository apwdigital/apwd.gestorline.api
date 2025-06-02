using Apwd.GestorLine.Services.Contracts.v1.BusinessOverview;
using Apwd.GestorLine.Services.Contracts.v1.Financial;
using Apwd.GestorLine.Services.Contracts.v1.System;
using Apwd.GestorLine.Services.Services.v1.BusinessOverview;
using Apwd.GestorLine.Services.Services.v1.Financial;
using Apwd.GestorLine.Services.Services.v1.System;
using Microsoft.Extensions.DependencyInjection;

namespace Apwd.GestorLine.Ioc.Extensions.v1;

public static class ServiceExtension
{
    public static IServiceCollection AddServiceContext(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFinancialService, FinancialService>();
        services.AddScoped<IDailyBillingService, DailyBillingService>();
        services.AddScoped<IMonthlyDataService, MonthlyDataService>();

        return services;
    }
}
