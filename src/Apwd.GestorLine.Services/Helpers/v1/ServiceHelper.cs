namespace Apwd.GestorLine.Services.Helpers.v1;

public static class ServiceHelper
{
    public static DateTime DateTime0(DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 3, 0, 0);
    }

    public static (string, string) GetStartAndEndDate(string year, string month)
    {
        var startDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1, 3, 0, 0);
        var endDate = startDate.AddMonths(1).AddDays(-1);
        return (DateToString10(startDate), DateToString10(endDate));
    }

    public static string DateToString10(DateTime date)
        => $"{date.Year}{date.Month.ToString().PadLeft(2, '0')}{date.Day.ToString().PadLeft(2, '0')}";

    public static DateTime DateString8ToDateTime(string stringValue)
    {
        var year = Convert.ToInt32(stringValue.Substring(0, 4));
        var month = Convert.ToInt32(stringValue.Substring(4, 2));
        var day = Convert.ToInt32(stringValue.Substring(6, 2));
        return new DateTime(year, month, day, 3, 0, 0);
    }

    public static string AddXToDateString8(string stringValue, string x, int n)
    {
        var year = Convert.ToInt32(stringValue.Substring(0, 4));
        var month = Convert.ToInt32(stringValue.Substring(4, 2));
        var day = Convert.ToInt32(stringValue.Substring(6, 2));
        var date = new DateTime(year, month, day, 3, 0, 0);

        if (x == "day")
            date = date.AddDays(n);

        if (x == "month")
            date = date.AddMonths(n);

        var padMonth = date.Month.ToString().PadLeft(2, '0');
        var padDay = date.Day.ToString().PadLeft(2, '0');

        return $"{date.Year}{padMonth}{padDay}";
    }

    public static string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);

        return new string(a);
    }
}