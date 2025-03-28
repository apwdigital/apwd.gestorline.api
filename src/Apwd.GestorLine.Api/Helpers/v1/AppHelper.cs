namespace Apwd.GestorLine.Api.Helpers.v1;

public static class AppHelper
{
    public static string GetAccountLevelCode(int level)
    {
        switch (level)
        {
            case 10:
                return "8d9cbb50";
            case 8:
                return "835b2384";
            default:
                return "b84481df";
        }
    }
}