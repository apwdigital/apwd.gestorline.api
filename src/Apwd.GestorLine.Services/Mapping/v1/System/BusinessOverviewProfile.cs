using Apwd.GestorLine.Domain.Entities.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.BusinessOverview;
using AutoMapper;

namespace Apwd.GestorLine.Services.Mapping.v1.System;

public class BusinessOverviewProfile : Profile
{
    public BusinessOverviewProfile()
    {
        CreateMap<MonthlyData, MonthlyDataPostRequest>().ReverseMap();
        CreateMap<MonthlyData, MonthlyDataModel>().ReverseMap();

        CreateMap<DailyBilling, DailyBillingPostRequest>().ReverseMap();
        CreateMap<DailyBilling, DailyBillingPutRequest>().ReverseMap();
        CreateMap<DailyBilling, DailyBillingResponse>().ReverseMap();
    }
}