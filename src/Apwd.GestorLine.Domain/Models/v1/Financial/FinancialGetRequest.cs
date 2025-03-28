namespace Apwd.GestorLine.Domain.Models.v1.Financial;

public class FinancialGetRequest
{
    public string? CompanyCode { get; set; }
    public string? Type { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public string? CategoryCode { get; set; }
    public string? AccountCode { get; set; }
    public string? ContactCode { get; set; }
    public string? Description { get; set; }
    public string? Year { get; set; }
    public string? Month { get; set; }
    public int Quantity { get; set; }    
}
