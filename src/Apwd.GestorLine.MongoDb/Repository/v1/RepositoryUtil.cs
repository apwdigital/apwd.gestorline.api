namespace Apwd.GestorLine.MongoDb.Repository.v1;

public static class RepositoryUtil
{
    public static int DateSubstring(string stringValue, int inicialPosition, int finalPOsition)
    {
        return Convert.ToInt32(stringValue.Substring(inicialPosition, finalPOsition));
    }

    public static DateTime ToCustomDateTime(string stringValue, int h, int m, int s)
    {
        var year = Convert.ToInt32(stringValue.Substring(0, 4));
        var month = Convert.ToInt32(stringValue.Substring(5, 2));
        var day = Convert.ToInt32(stringValue.Substring(8, 2));

        return new DateTime(year, month, day, h, m, s);
    }
}