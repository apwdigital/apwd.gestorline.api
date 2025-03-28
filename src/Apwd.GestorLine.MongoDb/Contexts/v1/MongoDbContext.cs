using Apwd.GestorLine.MongoDb.Contracts.v1;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Apwd.GestorLine.MongoDb.Contexts.v1;

public class MongoDbContext : IMongoDbContext
{
    private IMongoDatabase Database { get; set; }
    public IClientSessionHandle Session { get; set; }
    public MongoClient MongoClient { get; set; }

    private readonly IConfiguration _configutarion;
    private readonly List<Func<Task>> _commands;

    public MongoDbContext(IConfiguration configuration)
    {
        _configutarion = configuration;
        _commands = new List<Func<Task>>();
    }

    public async Task<int> SaveChanges()
    {
        ConfigureMongo();

        using (Session = await MongoClient.StartSessionAsync())
        {
            Session.StartTransaction();

            var commandTasks = _commands.Select(func => func());

            await Task.WhenAll(commandTasks);

            await Session.CommitTransactionAsync();
        }

        return _commands.Count;
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        ConfigureMongo();
        return Database.GetCollection<T>(name);
    }

    public void AddCommand(Func<Task> func) => _commands.Add(func);

    public void Dispose()
    {
        Session?.Dispose();
        GC.SuppressFinalize(this);
    }

    private void ConfigureMongo()
    {
        if (MongoClient != default) return;

        MongoClient = new MongoClient(_configutarion["MongoSettings:Connection"]);
        Database = MongoClient.GetDatabase(_configutarion["MongoSettings:DatabaseName"]);
    }
}
