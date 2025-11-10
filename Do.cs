namespace PFunP;

public static class Do
{
    public static T Scope<T>(Func<T> supplier)
    {
        ArgumentNullException.ThrowIfNull(supplier, nameof(supplier));

        return supplier();
    }

    public static T To<T>(T mutable, Action<T> mutator)
    {
        ArgumentNullException.ThrowIfNull(mutator, nameof(mutator));

        mutator(mutable);

        return mutable;
    }

    public static T Until<T>(T seed, Func<T, bool> condition, Func<T, T> accumulator)
    {
        ArgumentNullException.ThrowIfNull(condition, nameof(condition));
        ArgumentNullException.ThrowIfNull(accumulator, nameof(accumulator));

        while (!condition(seed))
        {
            seed = accumulator(seed);
        }

        return seed;
    }
}
