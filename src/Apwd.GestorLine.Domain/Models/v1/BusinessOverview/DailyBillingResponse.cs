namespace Apwd.GestorLine.Domain.Models.v1.BusinessOverview;

public class DailyBillingResponse
{
    public DailyBillingResponse()
    {
    }

    public required string Id { get; set; }
    public required string CompanyCode { get; set; }
    public int Code { get; set; }
    public required string Date { get; set; }
    public required string DayOfWeek { get; set; }
    public decimal GoalGrossAmount { get; set; }
    public decimal GrossAmount { get; set; }
    public int WorkDay { get; set; }
    public List<HourlyBillingModel> HourlyBillings { get; set; } = new List<HourlyBillingModel>();
}
