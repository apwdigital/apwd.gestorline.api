using System.Globalization;

namespace Apwd.GestorLine.Domain.Helpers.v1;

public class CultureInfoHelper
{
    public static DateTime GetDate()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");
        return DateTime.Now.AddHours(-3);
    }

    public static CultureInfo GetCultureInfo() => new CultureInfo("pt-BR");
}
