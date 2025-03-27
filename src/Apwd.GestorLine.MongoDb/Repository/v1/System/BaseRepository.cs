using Apwd.GestorLine.MongoDb.Contracts.v1;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;
using MongoDB.Driver;

namespace Apwd.GestorLine.MongoDb.Repository.v1.System
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDbContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoDbContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var query = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return query.ToList();
        }
        public virtual async Task<TEntity> GetAsync(string id)
        {
            var obj = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return obj.FirstOrDefault();
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public virtual async Task DeleteAsync(string id)

        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Task UpdateAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}