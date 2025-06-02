using Apwd.GestorLine.Domain.Entities.v1.System;
using Apwd.GestorLine.Domain.Models.v1.BusinessOverview;

namespace Apwd.GestorLine.Domain.Entities.v1.BusinessOverview;

public class DailyBilling : BaseEntity
{
    public int Code { get; set; }
    public required string DayOfWeek { get; set; }
    public decimal GoalGrossAmount { get; set; }
    public decimal GrossAmount { get; set; }
    public bool WorkDay { get; set; }
    public IEnumerable<HourlyBillingModel> HourlyBillings { get; set; } = new List<HourlyBillingModel>();
}