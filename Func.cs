namespace PFunP;

/// <summary>
/// Defines common functions to be used as delegate instances.
/// </summary>
public static class Func
{
    /// <summary>
    /// Returns the provided value.
    /// </summary>
    /// <typeparam name="T">The type of the value</typeparam>
    /// <param name="input">An object</param>
    /// <returns>Its input</returns>
    public static T Identity<T>(T input) => input;
}
