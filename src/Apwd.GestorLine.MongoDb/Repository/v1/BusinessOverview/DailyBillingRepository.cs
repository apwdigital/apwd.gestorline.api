using Apwd.GestorLine.Domain.Entities.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.Filters;
using Apwd.GestorLine.MongoDb.Contracts.v1;
using Apwd.GestorLine.MongoDb.Contracts.v1.BusinessOverview;
using Apwd.GestorLine.MongoDb.Repository.v1.System;
using MongoDB.Driver;

namespace Apwd.GestorLine.MongoDb.Repository.v1.BusinessOverview;

public class DailyBillingRepository : BaseRepository<DailyBilling>, IDailyBillingRepository
{
    public DailyBillingRepository(IMongoDbContext context) : base(context)
    {
    }

    public async Task<DailyBilling> GetByCode(SearchFilter filter)
    {
        var builder = Builders<DailyBilling>.Filter;
        var newfilter = builder.Empty;

        if (!string.IsNullOrWhiteSpace(filter.CompanyCode))
        {
            var customFilter = builder.Eq(x => x.CompanyCode, filter.CompanyCode);
            newfilter &= customFilter;
        }

        if (filter.YearMonthCode > 0)
        {
            var customListFilter = builder.Eq(x => x.Code, filter.YearMonthCode);
            newfilter &= customListFilter;
        }

        try
        {
            var obj = await DbSet.FindAsync(newfilter);
            return obj.FirstOrDefault();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<DailyBilling>> GetByCustonFilterAsync(SearchFilter filter)
    {
        var builder = Builders<DailyBilling>.Filter;
        var newfilter = builder.Empty;

        if (!string.IsNullOrWhiteSpace(filter.CompanyCode))
        {
            var customFilter = builder.Eq(x => x.CompanyCode, filter.CompanyCode);
            newfilter &= customFilter;
        }

        if (filter.YearMonthCode > 0)
        {
            var starCode = int.Parse($"{filter.YearMonthCode}01");
            var endCode = int.Parse($"{filter.YearMonthCode}31");

            newfilter &= Builders<DailyBilling>.Filter.Gte(x => x.Code, starCode);
            newfilter &= Builders<DailyBilling>.Filter.Lte(x => x.Code, endCode);
        }

        var objs = await DbSet.FindAsync(newfilter);
        return objs.ToList();
    }
}
