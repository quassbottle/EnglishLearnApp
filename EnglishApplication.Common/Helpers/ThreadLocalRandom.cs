namespace EnglishApplication.Common.Helpers;

public static class ThreadLocalRandom
{
    [ThreadStatic] private static Random? _local;

    public static Random Instance
    {
        get { return _local ??= new Random(); }
    }
}