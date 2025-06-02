namespace Apwd.GestorLine.Domain.Models.v1.Filters;

public class SearchFilter
{
    public string CompanyCode { get; set; }
    public int YearMonthCode { get; set; }
    public DateTime StartDate { get; set; }

    public SearchFilter()
    {

    }
    public SearchFilter(string companyCode, int yearMonthCode)
    {
        CompanyCode = companyCode;
        YearMonthCode = yearMonthCode;
    }

    public SearchFilter(string companyCode)
    {
        CompanyCode = companyCode;
    }
}