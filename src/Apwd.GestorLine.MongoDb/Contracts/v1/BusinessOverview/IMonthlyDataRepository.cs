using Apwd.GestorLine.Domain.Entities.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.Filters;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;

namespace Apwd.GestorLine.MongoDb.Contracts.v1.BusinessOverview;

public interface IMonthlyDataRepository : IBaseRepository<MonthlyData>
{
    Task<MonthlyData> GetByFilter(SearchFilter filter);
}