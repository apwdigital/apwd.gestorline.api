namespace Apwd.GestorLine.Domain.Models.v1.Financial;

public class FinancialGetResponse
{
    public List<FinancialResponse>? FinancialData { get; set; }
    public decimal PreviousBalance { get; set; }
}
