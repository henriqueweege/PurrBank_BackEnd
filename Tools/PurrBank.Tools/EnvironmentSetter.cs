namespace PurrBank.Tools
{
    public static class EnvironmentSetter
    {
        public static void SetTestEnvToTrue()
        {
            Environment.SetEnvironmentVariable("IsTestEnv", "true");
        }

        public static void SetTestEnvToFalse()
        {
            Environment.SetEnvironmentVariable("IsTestEnv", "false");
        }

        public static void SetTestEnvToNull()
        {
            Environment.SetEnvironmentVariable("IsTestEnv", null);
        }
    }
}
