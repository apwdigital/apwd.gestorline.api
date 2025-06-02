using Apwd.GestorLine.Domain.Models.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.Filters;

namespace Apwd.GestorLine.Services.Contracts.v1.BusinessOverview;

public interface IDailyBillingService
{
    Task<DailyBillingResponse> GetByCode(SearchFilter filter);
    Task<DailyBillingResponse> Update(DailyBillingPutRequest request);
}
