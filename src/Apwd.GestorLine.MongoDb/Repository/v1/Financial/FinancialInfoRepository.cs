using Apwd.GestorLine.Domain.Entities.v1.Financial;
using Apwd.GestorLine.MongoDb.Contracts.v1;
using Apwd.GestorLine.MongoDb.Contracts.v1.Financial;
using Apwd.GestorLine.MongoDb.Repository.v1.System;


namespace Apwd.GestorLine.MongoDb.Repository.v1.Financial;

public class FinancialInfoRepository : BaseRepository<FinancialInfo>, IFinancialInfoRepository
{
    public FinancialInfoRepository(IMongoDbContext context) : base(context)
    {
    }
}