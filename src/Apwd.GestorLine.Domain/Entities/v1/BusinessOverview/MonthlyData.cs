using Apwd.GestorLine.Domain.Entities.v1.System;
using Apwd.GestorLine.Domain.Models.v1.BusinessOverview;

namespace Apwd.GestorLine.Domain.Entities.v1.BusinessOverview;

public class MonthlyData : BaseEntity
{
    public int YearMonthCode { get; set; }
    public string Title { get; set; }
    public IEnumerable<MonthlyDataItemModel> Items { get; set; }
}