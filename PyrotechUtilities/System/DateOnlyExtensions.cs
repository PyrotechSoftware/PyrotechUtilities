#if NET6_0_OR_GREATER

namespace System
{
    /// <summary>
    /// Extension methods for <see cref="DateOnly"/>.
    /// </summary>
    public static class DateOnlyExtensions
    {
        /// <summary>
        /// Converts a <see cref="DateTime"/> to a <see cref="DateOnly"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to convert.</param>
        /// <returns>The equivalent <see cref="DateOnly"/>.</returns>
        public static DateOnly ToDateOnly(this DateTime dateTime)
        {
            return new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <summary>
        /// Converts a nullable <see cref="DateTime"/> to a nullable <see cref="DateOnly"/>.
        /// </summary>
        /// <param name="dateTime">The nullable <see cref="DateTime"/> to convert.</param>
        /// <returns>The equivalent nullable <see cref="DateOnly"/>.</returns>
        public static DateOnly? ToDateOnly(this DateTime? dateTime)
        {
            return dateTime.HasValue ? new DateOnly(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day) : null;
        }

        /// <summary>
        /// Converts a <see cref="DateOnly"/> to a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateOnly">The <see cref="DateOnly"/> to convert.</param>
        /// <returns>The equivalent <see cref="DateTime"/>.</returns>
        public static DateTime ToDateTime(this DateOnly dateOnly)
        {
            return new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);
        }

        /// <summary>
        /// Converts a nullable <see cref="DateOnly"/> to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateOnly">The nullable <see cref="DateOnly"/> to convert.</param>
        /// <returns>The equivalent nullable <see cref="DateTime"/>.</returns>
        public static DateTime? ToDateTime(this DateOnly? dateOnly)
        {
            return dateOnly.HasValue ? new DateTime(dateOnly.Value.Year, dateOnly.Value.Month, dateOnly.Value.Day) : null;
        }
    }
}

#endif