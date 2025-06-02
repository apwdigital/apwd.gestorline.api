using Apwd.GestorLine.Domain.Entities.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.Filters;
using Apwd.GestorLine.MongoDb.Contracts.v1;
using Apwd.GestorLine.MongoDb.Contracts.v1.BusinessOverview;
using Apwd.GestorLine.MongoDb.Repository.v1.System;
using MongoDB.Driver;

namespace Apwd.GestorLine.MongoDb.Repository.v1.BusinessOverview;

public class MonthlyDataRepository : BaseRepository<MonthlyData>, IMonthlyDataRepository
{
    public MonthlyDataRepository(IMongoDbContext context) : base(context)
    {
    }

    public async Task<MonthlyData> GetByFilter(SearchFilter filter)
    {
        var builder = Builders<MonthlyData>.Filter;
        var newfilter = builder.Empty;

        if (!string.IsNullOrWhiteSpace(filter.CompanyCode))
        {
            var customfilter = builder.Eq(x => x.CompanyCode, filter.CompanyCode);
            newfilter &= customfilter;
        }

        if (filter.YearMonthCode > 0)
        {
            var customfilter = builder.Eq(x => x.YearMonthCode, filter.YearMonthCode);
            newfilter &= customfilter;
        }

        var result = await DbSet.FindAsync(newfilter);
        return result.FirstOrDefault();
    }
}