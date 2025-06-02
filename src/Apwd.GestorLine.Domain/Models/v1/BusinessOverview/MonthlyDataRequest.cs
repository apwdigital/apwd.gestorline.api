namespace Apwd.GestorLine.Domain.Models.v1.BusinessOverview;
public class MonthlyDataRequest
{
    public string Id { get; set; }
    public string CompanyCode { get; set; }
    public int YearMonthCode { get; set; }
    public string Title { get; set; }
    public List<MonthlyDataItemModel> Items { get; set; } = new List<MonthlyDataItemModel>();
}