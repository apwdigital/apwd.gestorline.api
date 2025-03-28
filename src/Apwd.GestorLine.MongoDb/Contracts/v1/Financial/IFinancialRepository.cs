using Apwd.GestorLine.Domain.Entities.v1.Financial;
using Apwd.GestorLine.Domain.Models.v1.Financial;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;

namespace Apwd.GestorLine.MongoDb.Contracts.v1.Financial;

public interface IFinancialRepository : IBaseRepository<Domain.Entities.v1.Financial.Financial>
{
    Task<IEnumerable<Domain.Entities.v1.Financial.Financial>> GetFinancialAsync(FinancialGetRequest request);
    Task<decimal> GetPreviousBalanceAsync(FinancialGetRequest request);
}