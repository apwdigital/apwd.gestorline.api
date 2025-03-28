using Apwd.GestorLine.Domain.Entities.v1.Financial;
using Apwd.GestorLine.Domain.Models.v1.Financial;
using AutoMapper;

namespace Apwd.GestorLine.Services.Mapping.v1.System;

public class FinancialProfile : Profile
{
    public FinancialProfile()
    {
        CreateMap<Financial, FinancialPostRequest>().ReverseMap();
        CreateMap<Financial, FinancialPutRequest>().ReverseMap();
        CreateMap<Financial, FinancialResponse>().ReverseMap();
        CreateMap<FinancialInfo, FinancialInfoPostRequest>().ReverseMap();
        CreateMap<FinancialInfo, FinancialGetInfoResponse>().ReverseMap();
    }
}