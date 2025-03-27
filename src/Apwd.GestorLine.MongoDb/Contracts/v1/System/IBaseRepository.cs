namespace Apwd.GestorLine.MongoDb.Contracts.v1.System
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetAsync(string id);
        Task AddAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(string id);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
