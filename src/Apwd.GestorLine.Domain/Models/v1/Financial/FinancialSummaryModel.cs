namespace Apwd.GestorLine.Domain.Models.v1.Financial;

public class FinancialSummaryModel
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string StringAmount { get; set; }

    public FinancialSummaryModel(
        string description,
        decimal amount
        )
    {
        Description = description;
        Amount = amount;
        StringAmount = amount.ToString().Replace(".", ",");
    }
}