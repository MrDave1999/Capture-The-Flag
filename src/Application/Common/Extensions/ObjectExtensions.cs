namespace CTF.Application.Common.Extensions;

public static class ObjectExtensions
{
    /// <summary>
    /// Sets the property value of a specified object.
    /// </summary>
    /// <typeparam name="T">The type that represents the object.</typeparam>
    /// <param name="object">The object whose property value will be set.</param>
    /// <param name="value">The new property value.</param>
    /// <param name="propertyName">The property name.</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException">
    /// when the property name is not found in the object.
    /// </exception>
    public static void SetValue<T>(
        this T @object,
        object value,
        [CallerArgumentExpression(nameof(value))] string propertyName = null) where T : class
    {
        ArgumentNullException.ThrowIfNull(@object);
        ArgumentNullException.ThrowIfNull(value);
        Type type = @object.GetType();
        PropertyInfo propertyInfo = type.GetProperty(propertyName) ??
            throw new InvalidOperationException($"Property '{propertyName}' was not found in type '{type.Name}'.");

        propertyInfo.SetValue(@object, value);
    }
}
