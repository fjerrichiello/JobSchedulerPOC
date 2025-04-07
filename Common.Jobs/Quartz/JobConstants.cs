namespace Common.Jobs.Quartz;

public static class JobConstants
{
    public static class WireTimeoutJob
    {
        public const string Name = "WireTimeoutJob";
        public const string Group = "WireTimeoutJob";

        public static class JobData
        {
            public const string WireNumber = "WireNumber";
            public const string MessageContainer = "MessageContainer";
        }
    }
}