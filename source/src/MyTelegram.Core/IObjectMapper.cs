using System.Diagnostics.CodeAnalysis;

namespace MyTelegram.Core;

/// <summary>
///     Defines a simple interface to automatically map objects.
/// </summary>
public interface IObjectMapper
{
    /// <summary>
    ///     Converts an object to another. Creates a new object of <see cref="TDestination" />.
    /// </summary>
    /// <typeparam name="TDestination">Type of the destination object</typeparam>
    /// <typeparam name="TSource">Type of the source object</typeparam>
    /// <param name="source">Source object</param>
    [return: NotNullIfNotNull("source")]
    TDestination? Map<TSource, TDestination>(TSource source);

    /// <summary>
    ///     Execute a mapping from the source object to the existing destination object
    /// </summary>
    /// <typeparam name="TSource">Source type</typeparam>
    /// <typeparam name="TDestination">Destination type</typeparam>
    /// <param name="source">Source object</param>
    /// <param name="destination">Destination object</param>
    /// <returns>Returns the same <see cref="destination" /> object after mapping operation</returns>
    [return: NotNullIfNotNull("source")]
    TDestination? Map<TSource, TDestination>(TSource source,
        TDestination destination);
}