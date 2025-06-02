namespace Apwd.GestorLine.Domain.Models.v1.BusinessOverview;

public class MonthlyDataPostRequest
{    
    public required string CompanyCode { get; set; }
    public int YearMonthCode { get; set; }
    public required string Title { get; set; }
    public List<MonthlyDataItemModel> Items { get; set; } = new List<MonthlyDataItemModel>();
}