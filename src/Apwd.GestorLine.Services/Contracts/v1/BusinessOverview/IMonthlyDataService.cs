using Apwd.GestorLine.Domain.Models.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.Filters;

namespace Apwd.GestorLine.Services.Contracts.v1.BusinessOverview;

public interface IMonthlyDataService
{
    Task<MonthlyDataModel> GetByFilter(SearchFilter filter);
    Task<MonthlyDataModel> GetById(string id);
    Task<MonthlyDataModel> Add(MonthlyDataPostRequest request);
    Task<int> Update(MonthlyDataRequest request);
}