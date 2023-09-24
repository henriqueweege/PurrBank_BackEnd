namespace Bank.Tools;

public static class EnvironmentVerifier
{
    public static bool IsTestEnv()
    {
        var isTestEnv = Environment.GetEnvironmentVariable("IsTestEnv");
        if (isTestEnv != null && bool.Parse(isTestEnv)) return true;
        return false;
    }
}
