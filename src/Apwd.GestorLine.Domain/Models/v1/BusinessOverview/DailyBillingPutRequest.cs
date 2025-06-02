namespace Apwd.GestorLine.Domain.Models.v1.BusinessOverview;

public class DailyBillingPutRequest : DailyBillingPostRequest
{
    public required string Id { get; set; }
}