namespace Apwd.GestorLine.Domain.Models.v1.Financial;

public class FinancialInfoPostRequest
{
    public required string CompanyCode { get; set; }
    public List<SharedEntityModel>? Categories { get; set; }
    public List<SharedEntityModel>? Accounts { get; set; }
    public List<SharedEntityModel>? PaymentTypes { get; set; }
    public List<SharedEntityModel>? Contacts { get; set; }
}