using Apwd.GestorLine.Domain.Entities.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Helpers.v1;
using Apwd.GestorLine.Domain.Models.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.Filters;
using Apwd.GestorLine.MongoDb.Contracts.v1.BusinessOverview;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;
using Apwd.GestorLine.Services.Contracts.v1.BusinessOverview;
using Apwd.GestorLine.Services.Helpers.v1;
using AutoMapper;
using System.Globalization;

namespace Apwd.GestorLine.Services.Services.v1.BusinessOverview;

public class DailyBillingService : IDailyBillingService
{
    private readonly IDailyBillingRepository _dailyBillingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DailyBillingService(
            IDailyBillingRepository dailyBillingRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
    {
        _dailyBillingRepository = dailyBillingRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DailyBillingResponse> GetByCode(SearchFilter filter)
    {
        var dailyBilling = await _dailyBillingRepository.GetByCode(filter);

        try
        {
            if (dailyBilling == null)
            {
                DailyBillingResponse bcModel = new DailyBillingResponse()
                {
                    Id = Guid.NewGuid().ToString(),
                    CompanyCode = filter.CompanyCode,
                    Code = filter.YearMonthCode,
                    Date = filter.StartDate.ToString("dd/MM/yyyy"),
                    DayOfWeek = ServiceHelper.UppercaseFirst(new CultureInfo("pt-BR").DateTimeFormat.GetDayName(filter.StartDate.DayOfWeek)),
                    WorkDay = 1,
                    GoalGrossAmount = 0,
                };

                var newObj = _mapper.Map<DailyBilling>(bcModel);

                newObj.CreatedAt = newObj.ChangedAt;

                await _dailyBillingRepository.AddAsync(newObj);

                await _unitOfWork.CommitAsync();

                dailyBilling = await _dailyBillingRepository.GetByCode(filter);
            }
            else
                return _mapper.Map<DailyBillingResponse>(dailyBilling);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro {ex}");
            dailyBilling = null;
        }

        return _mapper.Map<DailyBillingResponse>(dailyBilling);
    }

    public async Task<DailyBillingResponse> Update(DailyBillingPutRequest request)
    {
        try
        {
            var objToUpdate = _mapper.Map<DailyBilling>(request);

            objToUpdate.ChangedAt = CultureInfoHelper.GetDate();

            await _dailyBillingRepository.UpdateAsync(objToUpdate);
            await _unitOfWork.CommitAsync();

            var DailyBillingResponse = _mapper.Map<DailyBillingResponse>(objToUpdate);

            return DailyBillingResponse;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"DailyBillingService Update Error: {ex.Message}");
            return _mapper.Map<DailyBillingResponse>(_mapper.Map<DailyBilling>(request));
        }
    }
}