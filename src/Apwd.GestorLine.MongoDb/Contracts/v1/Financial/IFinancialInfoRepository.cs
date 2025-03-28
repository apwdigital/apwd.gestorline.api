using Apwd.GestorLine.Domain.Entities.v1.Financial;
using Apwd.GestorLine.MongoDb.Contracts.v1.System;

namespace Apwd.GestorLine.MongoDb.Contracts.v1.Financial;

public interface IFinancialInfoRepository : IBaseRepository<FinancialInfo>
{
}
