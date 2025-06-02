using Apwd.GestorLine.Domain.Enums;

namespace Apwd.GestorLine.Domain.Models.v1.BusinessOverview;

public class MonthlyDataItemModel
{
    public required string Title { get; set; }
    public decimal Amount { get; set; }
    public required string StringValue { get; set; }
    public int Sequence { get; set; }
    public EDataType DataType { get; set; }
}
