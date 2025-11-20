#if NET7_0_OR_GREATER

namespace System;

using System.Numerics;
using System.Globalization;

/// <summary>
/// Extensions for numeric types.
/// </summary>
public static class NumericExtensions
{
    public static string ToFileSize<T>(this T value, CultureInfo? culture = null) where T : INumber<T>
    {
        culture ??= CultureInfo.CurrentCulture;
        decimal num = Convert.ToDecimal(value) / 1024m;
        decimal num2 = num / 1024m;
        return !(num < 1024m)
            ? string.Format(culture, "{0:0.00} MB", num2)
            : string.Format(culture, "{0:00.00} KB", num);
    }
}

#endif