namespace Apwd.GestorLine.Domain.Models.v1.Financial;

public class FinancialResponse
{
    public required string Id { get; set; }
    public required string CompanyCode { get; set; }
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
    public decimal Balance { get; set; }
    public string? DocumentNumber { get; set; }
    public required string Description { get; set; }
    public required string EmittentDate { get; set; }
    public required string DueDate { get; set; }
    public string? PayDate { get; set; }
    public required string PlanningType { get; set; }
    public string? Comments { get; set; }
    public int Sequence { get; set; }
    public DateTime? ChangedAt { get; set; }
    public string? Tag { get; set; }
    public string? LoteCode { get; set; }
}