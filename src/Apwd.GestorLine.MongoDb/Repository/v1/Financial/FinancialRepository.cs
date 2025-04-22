using Apwd.GestorLine.Domain.Models.v1.Financial;
using Apwd.GestorLine.MongoDb.Contracts.v1;
using Apwd.GestorLine.MongoDb.Contracts.v1.Financial;
using Apwd.GestorLine.MongoDb.Repository.v1.System;
using MongoDB.Driver;

namespace Apwd.GestorLine.MongoDb.Repository.v1.Financial;

public class FinancialRepository : BaseRepository<Domain.Entities.v1.Financial.Financial>, IFinancialRepository
{
    public FinancialRepository(IMongoDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Entities.v1.Financial.Financial>> GetFinancialAsync(FinancialGetRequest request)
    {
        var builder = Builders<Domain.Entities.v1.Financial.Financial>.Filter;
        var newfilter = builder.Empty;

        if (!string.IsNullOrWhiteSpace(request.CompanyCode))
        {
            var customListFilter = builder.Eq(x => x.CompanyCode, request.CompanyCode);
            newfilter &= customListFilter;
        }

        var beginDateFilter = RepositoryUtil.ToCustomDateTime(request.StartDate, 0, 0, 0);
        var endDateFilter = RepositoryUtil.ToCustomDateTime(request.EndDate, 23, 59, 59);
        newfilter &= Builders<Domain.Entities.v1.Financial.Financial>.Filter.Gte(x => x.DueDate, beginDateFilter);
        newfilter &= Builders<Domain.Entities.v1.Financial.Financial>.Filter.Lte(x => x.DueDate, endDateFilter);

        if (!string.IsNullOrWhiteSpace(request.Type))
        {
            var customListFilter = builder.Eq(x => x.Type, request.Type);
            newfilter &= customListFilter;
        }

        if (!string.IsNullOrWhiteSpace(request.Type))
        {
            var customListFilter = builder.Eq(x => x.Type, request.Type);
            newfilter &= customListFilter;
        }

        if (!string.IsNullOrWhiteSpace(request.CategoryCode))
        {
            var customListFilter = builder.Eq(x => x.CategoryCode, request.CategoryCode);
            newfilter &= customListFilter;
        }

        if (!string.IsNullOrWhiteSpace(request.AccountCode))
        {
            var customListFilter = builder.Eq(x => x.AccountCode, request.AccountCode);
            newfilter &= customListFilter;
        }

        if (!string.IsNullOrWhiteSpace(request.ContactCode))
        {
            var customListFilter = builder.Eq(x => x.ContactCode, request.ContactCode);
            newfilter &= customListFilter;
        }

        try
        {
            var objs = await DbSet.FindAsync(newfilter);
            return objs.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[FinancialRepository] erro: {ex.Message}");
            throw;
        }
    }

    public async Task<decimal> GetPreviousBalanceAsync(FinancialGetRequest request)
    {
        var builder = Builders<Domain.Entities.v1.Financial.Financial>.Filter;
        var newfilter = builder.Empty;

        if (!string.IsNullOrWhiteSpace(request.CompanyCode))
        {
            var customListFilter = builder.Eq(x => x.CompanyCode, request.CompanyCode);
            newfilter &= customListFilter;
        }

        if (request.StartDate != null && request.EndDate != null)
        {
            var beginDateFilter = RepositoryUtil.ToCustomDateTime(request.StartDate, 0, 0, 0);
            newfilter &= Builders<Domain.Entities.v1.Financial.Financial>.Filter.Lt(x => x.DueDate, beginDateFilter);
        }

        if (!string.IsNullOrWhiteSpace(request.AccountCode))
        {
            var customListFilter = builder.Eq(x => x.AccountCode, request.AccountCode);
            newfilter &= customListFilter;
        }

        decimal totalAmount = 0;

        try
        {
            var objs = await DbSet.FindAsync(newfilter);
            totalAmount = objs.ToList().Sum(f => f.Amount);
        }
        catch (Exception ex)
        {
            totalAmount = 0;
            Console.WriteLine($"[FinancialRepository:GetPreviousBalanceAsync] erro: {ex.Message}");
        }

        return totalAmount;
    }
}