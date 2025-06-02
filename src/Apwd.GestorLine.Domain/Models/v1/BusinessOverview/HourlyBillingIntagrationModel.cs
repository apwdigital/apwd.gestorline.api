namespace Apwd.GestorLine.Domain.Models.v1.BusinessOverview;

public class HourlyBillingIntagrationModel
{
    public required string CompanyCode { get; set; }
    public int DailyBillingCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal GrossAmount { get; set; }
}