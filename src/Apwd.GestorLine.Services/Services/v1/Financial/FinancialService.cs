﻿using Apwd.GestorLine.Domain.Entities.v1.Financial;
using Apwd.GestorLine.Domain.Helpers.v1;
using Apwd.GestorLine.Domain.Models.v1;
using Apwd.GestorLine.Domain.Models.v1.Financial;
using Apwd.GestorLine.MongoDb.Contracts.v1.Financial;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;
using Apwd.GestorLine.Services.Contracts.v1.Financial;
using Apwd.GestorLine.Services.Helpers.v1;
using AutoMapper;

namespace Apwd.GestorLine.Services.Services.v1.Financial;

public class FinancialService : IFinancialService
{
    private readonly IFinancialRepository _financialRepository;
    private readonly IFinancialInfoRepository _financialInfoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FinancialService(
        IFinancialRepository financialRepository,
        IFinancialInfoRepository financialInfoRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _financialRepository = financialRepository;
        _financialInfoRepository = financialInfoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<FinancialGetResponse> GetAsync(FinancialGetRequest request)
    {
        var repositoryResponse = _mapper.Map<IEnumerable<FinancialResponse>>(await _financialRepository.GetFinancialAsync(request));

        var previousBalance = string.IsNullOrWhiteSpace(request.Type) ? await _financialRepository.GetPreviousBalanceAsync(request) : 0;

        var balance = previousBalance;

        repositoryResponse = repositoryResponse.OrderBy(o => o.DueDate).ThenBy(o => o.Sequence).ToList();

        foreach (var item in repositoryResponse)
        {
            balance = balance + item.Amount;
            item.Balance = balance;
        }

        return new FinancialGetResponse()
        {
            FinancialData = repositoryResponse.ToList(),
            PreviousBalance = previousBalance
        };
    }

    public async Task<FinancialResponse> GetById(string id)
        => _mapper.Map<FinancialResponse>(await _financialRepository.GetAsync(id));

    public async Task<FinancialGetInfoResponse> GetInfoAsync(string CompanyCode)
    {
        var financialInfo = await _financialInfoRepository.GetByFilterAsync(new SearchFilterModel(CompanyCode));

        return new FinancialGetInfoResponse()
        {
            Categories = financialInfo.FirstOrDefault()?.Categories.OrderBy(o => o.Description).ToList(),
            Accounts = financialInfo.FirstOrDefault()?.Accounts.OrderBy(o => o.Description).ToList(),
            PaymentTypes = financialInfo.FirstOrDefault()?.PaymentTypes.OrderBy(o => o.Description).ToList(),
            Contacts = financialInfo.FirstOrDefault()?.Contacts.OrderBy(o => o.Description).ToList()
        };
    }

    public async Task<FinancialResponse> Add(FinancialPostRequest request)
    {
        try
        {
            var objToAdd = _mapper.Map<Domain.Entities.v1.Financial.Financial>(request);
            objToAdd.Id = Guid.NewGuid().ToString();
            objToAdd.DueDate = new DateTime(objToAdd.DueDate.Year, objToAdd.DueDate.Month, objToAdd.DueDate.Day, 3, 0, 0);
            objToAdd.DueDateCode = Convert.ToInt32($"{request.DueDate.Year}{request.DueDate.Month.ToString().PadLeft(2, '0')}");
            objToAdd.ChangedAt = objToAdd.CreatedAt;

            await _financialRepository.AddAsync(objToAdd);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<FinancialResponse>(objToAdd);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"IFinancialRepository Add Error: {ex.Message}");
            throw;
        }
    }

    public async Task<int> Update(FinancialPutRequest request)
    {
        try
        {
            var objToUpdate = _mapper.Map<Domain.Entities.v1.Financial.Financial>(request);
            objToUpdate.DueDate = new DateTime(objToUpdate.DueDate.Year, objToUpdate.DueDate.Month, objToUpdate.DueDate.Day, 3, 0, 0);
            objToUpdate.DueDateCode = Convert.ToInt32($"{request.DueDate.Year}{request.DueDate.Month.ToString().PadLeft(2, '0')}");
            objToUpdate.ChangedAt = CultureInfoHelper.GetDate();

            await _financialRepository.UpdateAsync(objToUpdate);
            await _unitOfWork.CommitAsync();
            return 200;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"IFinancialRepository Update Error: {ex.Message}");
            return 500;
        }
    }

    public async Task<int> UpdateCategory(FinancialResponse request)
    {
        try
        {
            request.ChangedAt = DateTime.Now;
            await _financialRepository.UpdateAsync(_mapper.Map<Domain.Entities.v1.Financial.Financial>(request));
            await _unitOfWork.CommitAsync();
            return 200;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"IFinancialRepository Update Error: {ex.Message}");
            return 500;
        }
    }

    public async Task<int> Delete(string id)
    {

        await _financialRepository.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return 200;
    }

    public async Task<FinancialResponse> Duplicate(FinancialResponse financialData)
    {
        var objToAdd = _mapper.Map<Domain.Entities.v1.Financial.Financial>(financialData);

        objToAdd.Id = Guid.NewGuid().ToString();
        objToAdd.DueDate = financialData.DueDate;
        objToAdd.PayDate = null;
        objToAdd.PlanningType = "P";
        objToAdd.DocumentNumber = string.Empty;

        await _financialRepository.AddAsync(objToAdd);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<FinancialResponse>(objToAdd);
    }

    public async Task<List<FinancialMonthlySummariesModel>> GetSummary(string CompanyCode, string year, string month, int quantity)
    {
        var filter = new SearchFilterModel(CompanyCode);
        var request = new FinancialGetRequest();
        request.CompanyCode = CompanyCode;

        var financialMonthlySummaries = new List<FinancialMonthlySummariesModel>();

        var financialInfo = _financialInfoRepository.GetByFilterAsync(filter).Result;

        var categories = financialInfo.FirstOrDefault()?.Categories.OrderBy(o => o.Description).ToList();

        if (quantity < 1 || quantity > 12) quantity = 1;

        for (int i = 0; i < quantity; i++)
        {
            if (i > 0)
            {
                month = (Convert.ToInt32(month) + 1).ToString();

                if (month == "13")
                {
                    year = (Convert.ToInt32(year) + 1).ToString();
                    month = "1";
                }
            }

            (request.StartDate, request.EndDate) = ServiceHelper.GetStartAndEndDate(year, month);

            var financialData = await _financialRepository.GetFinancialAsync(request);

            List<FinancialSummaryModel> summary = new List<FinancialSummaryModel>();
            foreach (var item in categories)
            {
                FinancialSummaryModel _item
                    = new FinancialSummaryModel(
                        item.Description,
                        financialData.ToList().Where(f => f.Category == item.Description).Sum(f => f.Amount)

                        );

                summary.Add(_item);
            }

            financialMonthlySummaries.Add(
                new FinancialMonthlySummariesModel
                {
                    Code = request.StartDate.Substring(0, 6),
                    Description = $"Ano {request.StartDate.Substring(0, 4)} mês {request.StartDate.Substring(4, 2)}",
                    FinancialSummary = summary.OrderBy(o => o.Description).ToList()
                });
        }

        return financialMonthlySummaries;
    }

    public async Task<FinancialGetInfoResponse> AddInfoAsync(FinancialInfoPostRequest request)
    {
        var objToAdd = _mapper.Map<FinancialInfo>(request);
        //objToAdd.Id = Guid.NewGuid().ToString();
        await _financialInfoRepository.AddAsync(objToAdd);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<FinancialGetInfoResponse>(objToAdd);
    }
}