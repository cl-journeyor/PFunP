namespace PFunP;

/// <summary>
/// Utility pure functions.
/// </summary>
public static class Do
{
    /// <summary>
    /// Returns an infinite sequence starting from a seed value to be accumulated.
    /// </summary>
    /// <typeparam name="T">The type of the items of the sequence</typeparam>
    /// <param name="seed">The first item in the sequence the following ones will be originated from</param>
    /// <param name="accumulator">A method that supplies the next value according to its argument</param>
    /// <returns>The infinite sequence</returns>
    public static IEnumerable<T> Iterate<T>(T seed, Func<T, T> accumulator)
    {
        ArgumentNullException.ThrowIfNull(accumulator, nameof(accumulator));

        while (true)
        {
            yield return seed;

            seed = accumulator(seed);
        }
    }

    /// <summary>
    /// Returns an infinite sequence by repeating the provided value.
    /// </summary>
    /// <typeparam name="T">The type of the repeated value.</typeparam>
    /// <param name="item">The item to be repeated in the sequence</param>
    /// <returns>The infinite sequence</returns>
    public static IEnumerable<T> Repeat<T>(T item)
    {
        while (true)
        {
            yield return item;
        }
    }

    /// <summary>
    /// Defines a new local scope on which statements may be written in order to return a new value.
    /// </summary>
    /// <typeparam name="T">The type of the value this local scope returns</typeparam>
    /// <param name="supplier">A parameterless function that allows writting statements within an expression</param>
    /// <returns>What the function returns</returns>
    public static T Scope<T>(Func<T> supplier)
    {
        ArgumentNullException.ThrowIfNull(supplier, nameof(supplier));

        return supplier();
    }

    /// <summary>
    /// Takes a mutable object, mutates it with the provided mutator function and returns the mutated object.
    /// </summary>
    /// <typeparam name="T">The type of the mutable object</typeparam>
    /// <param name="mutable">An object</param>
    /// <param name="mutator">A procedure that takes the mutable object</param>
    /// <returns>The mutated object</returns>
    public static T To<T>(T mutable, Action<T> mutator)
    {
        ArgumentNullException.ThrowIfNull(mutator, nameof(mutator));

        mutator(mutable);

        return mutable;
    }

    /// <summary>
    /// Emulates tail recursion. Accumulates the provided seed on loop; returns when the condition is true.
    /// </summary>
    /// <typeparam name="T">The type of the initial value of this looping function</typeparam>
    /// <param name="seed">The value to be tested and accumulated; usually a tuple</param>
    /// <param name="condition">The condition that controls the loop</param>
    /// <param name="accumulator">A function to be applied to seed</param>
    /// <returns>The result of accumulating the seed once the condition is true</returns>
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
