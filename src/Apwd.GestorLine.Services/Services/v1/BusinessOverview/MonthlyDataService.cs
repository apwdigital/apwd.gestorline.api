using Apwd.GestorLine.Domain.Entities.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.Filters;
using Apwd.GestorLine.MongoDb.Contracts.v1.BusinessOverview;
using Apwd.GestorLine.MongoDb.Contracts.v1.Financial;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;
using Apwd.GestorLine.Services.Contracts.v1.BusinessOverview;
using AutoMapper;

namespace Apwd.GestorLine.Services.Services.v1.BusinessOverview;

public class MonthlyDataService : IMonthlyDataService
{
    private readonly IMonthlyDataRepository _monthlyDataRepository;
    private readonly IDailyBillingRepository _dailyBillingRepository;
    private readonly IFinancialRepository _financialRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MonthlyDataService(
        IMonthlyDataRepository monthlyDataRepository,
        IDailyBillingRepository dailyBillingRepository,
        IFinancialRepository financialRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _monthlyDataRepository = monthlyDataRepository;
        _dailyBillingRepository = dailyBillingRepository;
        _financialRepository = financialRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MonthlyDataModel> GetByFilter(SearchFilter filter)
    {
        try
        {
            var model = await _monthlyDataRepository.GetByFilter(filter);

            if (model != null)
            {
                var monthlyDataModel = _mapper.Map<MonthlyDataModel>(model);

                var dailyBillings = await _dailyBillingRepository.GetByCustonFilterAsync(filter);
                monthlyDataModel.DailyBillings = _mapper.Map<IEnumerable<DailyBillingResponse>>(dailyBillings);

                foreach (var item in monthlyDataModel.DailyBillings)
                    item.Date = CodeToDateString(item.Code.ToString());

                monthlyDataModel.DailyBillings = monthlyDataModel.DailyBillings.OrderBy(x => x.Date);                

                return monthlyDataModel;
            }
            else
            {
                return new MonthlyDataModel();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<MonthlyDataModel> Add(MonthlyDataPostRequest request)
    {
        var newObj = _mapper.Map<MonthlyData>(request);
        newObj.Id = Guid.NewGuid().ToString();

        await _monthlyDataRepository.AddAsync(newObj);

        await _unitOfWork.CommitAsync();

        return _mapper.Map<MonthlyDataModel>(newObj);
    }

    public async Task<MonthlyDataModel> GetById(string id)
        => _mapper.Map<MonthlyDataModel>(await _monthlyDataRepository.GetAsync(id));

    public async Task<int> Update(MonthlyDataRequest request)
    {
        try
        {
            var objToUpdate = _mapper.Map<MonthlyData>(request);            

            await _monthlyDataRepository.UpdateAsync(objToUpdate);
            await _unitOfWork.CommitAsync();
            return 200;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"MonthlyDataService Update Error: {ex.Message}");
            return 500;
        }
    }

    internal string CodeToDateString(string dateStr)
        => $"{dateStr.Substring(6, 2)}/{dateStr.Substring(4, 2)}/{dateStr.Substring(0, 4)}";

}