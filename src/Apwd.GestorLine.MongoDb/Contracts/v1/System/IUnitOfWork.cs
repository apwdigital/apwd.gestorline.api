namespace Apwd.GestorLine.MongoDb.Contracts.v1.System
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
