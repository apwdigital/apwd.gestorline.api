using Apwd.GestorLine.Domain.Models.v1.Financial;

namespace Apwd.GestorLine.Domain.Models.v1.BusinessOverview;

public class MonthlyDataModel
{
    public string Id { get; set; }
    public string CompanyCode { get; set; }
    public int YearMonthCode { get; set; }
    public string Title { get; set; }
    public IEnumerable<MonthlyDataItemModel> Items { get; set; } = new List<MonthlyDataItemModel>();
    public IEnumerable<DailyBillingResponse> DailyBillings { get; set; } = new List<DailyBillingResponse>();
    public DateTime? ChangedAt { get; set; }
    public IEnumerable<FinancialSummaryModel> FinancialSummary { get; set; } = new List<FinancialSummaryModel>();
}