using Apwd.GestorLine.Domain.Entities.v1.System;
using Apwd.GestorLine.Domain.Models.v1;

namespace Apwd.GestorLine.Domain.Entities.v1.Financial;

public class FinancialInfo : BaseEntity
{
    public required List<SharedEntityModel> Accounts { get; set; }
    public required List<SharedEntityModel> Categories { get; set; }
    public required List<SharedEntityModel> PaymentTypes { get; set; }
    public required List<SharedEntityModel> Contacts { get; set; }
}
