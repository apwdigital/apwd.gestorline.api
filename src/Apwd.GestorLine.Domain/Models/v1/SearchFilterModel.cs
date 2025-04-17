namespace Apwd.GestorLine.Domain.Models.v1;

public class SearchFilterModel
{
    public string? CompanyCode { get; set; }
    public SearchFilterModel(string companyCode)
    {
        CompanyCode = companyCode;
    }
}