namespace Apwd.GestorLine.Domain.Models.v1.Financial;

public class FinancialMonthlySummariesModel
{
    public string? Code { get; set; }
    public string? Description { get; set; }
    public List<FinancialSummaryModel>? FinancialSummary { get; set; }
}