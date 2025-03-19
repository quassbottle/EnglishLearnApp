namespace EnglishApplication.Common.Helpers;

/// <summary>
/// Статический класс для создания потокобезопасных случайных чисел.
/// </summary>
public static class ThreadLocalRandom
{
    [ThreadStatic]
    private static Random? _local;

    /// <summary>
    /// Возвращает экземпляр класса Random, уникальный для каждого потока.
    /// </summary>
    public static Random Instance
    {
        get { return _local ??= new Random(); }
    }
}