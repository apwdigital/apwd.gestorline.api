using Apwd.GestorLine.Domain.Models.v1.Financial;

namespace Apwd.GestorLine.Services.Contracts.v1.Financial;

public interface IFinancialService
{
    Task<FinancialGetResponse> GetAsync(FinancialGetRequest request);
    Task<FinancialResponse> GetById(string id);
    Task<FinancialGetInfoResponse> GetInfoAsync(string CompanyCode);    
    Task<FinancialResponse> Add(FinancialPostRequest request);
    Task<FinancialResponse> Duplicate(FinancialResponse financialData);
    Task<List<FinancialMonthlySummariesModel>> GetSummary(string CompanyCode, string year, string month, int quantity);
    Task<int> Update(FinancialPutRequest request);
    Task<int> UpdateCategory(FinancialResponse request);
    Task<int> Delete(string id);
    Task<FinancialGetInfoResponse> AddInfoAsync(FinancialInfoPostRequest request);
}
