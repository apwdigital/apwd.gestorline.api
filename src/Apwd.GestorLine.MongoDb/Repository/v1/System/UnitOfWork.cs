using Apwd.GestorLine.MongoDb.Contracts.v1;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;

namespace Apwd.GestorLine.MongoDb.Repository.v1.System;

public class UnitOfWork : IUnitOfWork
{
    private readonly IMongoDbContext _context;

    public UnitOfWork(IMongoDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync()
    {
        try
        {
            var AffectedDocuments = await _context.SaveChanges();
            return AffectedDocuments > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[UnitOfWork error]: {ex.Message}");
            return false;
        }
    }

    public void Dispose() => _context.Dispose();
}
