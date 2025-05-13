#if NET7_0_OR_GREATER

namespace System
{
    using System.Numerics;

    /// <summary>
    /// Extensions for numeric types.
    /// </summary>
    public static class NumericExtensions
    {
        public static string ToFileSize<T>(this T value) where T : INumber<T>
        {
            decimal num = Convert.ToDecimal(value) / 1024m;
            decimal num2 = num / 1024m;
            return !(num < 1024m) ? $"{num2:0.00}" + " MB" : $"{num:00.00}" + " KB";
        }
    }
}

#endif