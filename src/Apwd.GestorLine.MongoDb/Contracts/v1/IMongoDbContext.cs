using MongoDB.Driver;

namespace Apwd.GestorLine.MongoDb.Contracts.v1;

public interface IMongoDbContext : IDisposable
{
    void AddCommand(Func<Task> func);
    Task<int> SaveChanges();
    IMongoCollection<T> GetCollection<T>(string name);
}
