using Apwd.GestorLine.Domain.Entities.v1.System;

namespace Apwd.GestorLine.Domain.Entities.v1.Financial;

public class Financial : BaseEntity
{
    public required string Type { get; set; }
    public required string CategoryCode { get; set; }
    public required string Category { get; set; }
    public required string AccountCode { get; set; }
    public required string Account { get; set; }
    public required string ContactCode { get; set; }
    public required string Contact { get; set; }
    public required string PaymentTypeCode { get; set; }
    public required string PaymentType { get; set; }
    public decimal Amount { get; set; }
    public string? DocumentNumber { get; set; }
    public required string Description { get; set; }
    public DateTime EmittentDate { get; set; }
    public DateTime DueDate { get; set; }
    public int DueDateCode { get; set; }
    public DateTime? PayDate { get; set; }
    public required string PlanningType { get; set; }
    public string? Comments { get; set; }
    public int Sequence { get; set; }
    public string? LoteCode { get; set; }
    public string? Tag { get; set; }
}