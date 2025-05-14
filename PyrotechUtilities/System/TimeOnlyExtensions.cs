#if NET6_0_OR_GREATER

namespace System
{
    public static class TimeOnlyExtensions
    {
        /// <summary>
        /// Converts a <see cref="TimeSpan"/> to a <see cref="TimeOnly"/>.
        /// </summary>
        /// <param name="timeSpan">The <see cref="TimeSpan"/> to convert.</param>
        /// <returns>The converted <see cref="TimeOnly"/>.</returns>
        public static TimeOnly ToTimeOnly(this TimeSpan timeSpan)
        {
            return new TimeOnly(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        /// <summary>
        /// Converts a nullable <see cref="TimeSpan"/> to a nullable <see cref="TimeOnly"/>.
        /// </summary>
        /// <param name="timeSpan">The nullable <see cref="TimeSpan"/> to convert.</param>
        /// <returns>The converted nullable <see cref="TimeOnly"/>.</returns>
        public static TimeOnly? ToTimeOnly(this TimeSpan? timeSpan)
        {
            return timeSpan.HasValue ? new TimeOnly(timeSpan.Value.Hours, timeSpan.Value.Minutes, timeSpan.Value.Seconds) : null;
        }

        /// <summary>
        /// Converts a <see cref="TimeOnly"/> to a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="timeOnly">The <see cref="TimeOnly"/> to convert.</param>
        /// <returns>The converted <see cref="TimeSpan"/>.</returns>
        public static TimeSpan ToTimeSpan(this TimeOnly timeOnly)
        {
            return new TimeSpan(timeOnly.Hour, timeOnly.Minute, timeOnly.Second);
        }

        /// <summary>
        /// Converts a nullable <see cref="TimeOnly"/> to a nullable <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="timeOnly">The nullable <see cref="TimeOnly"/> to convert.</param>
        /// <returns>The converted nullable <see cref="TimeSpan"/>.</returns>
        public static TimeSpan? ToTimeSpan(this TimeOnly? timeOnly)
        {
            return timeOnly.HasValue ? new TimeSpan(timeOnly.Value.Hour, timeOnly.Value.Minute, timeOnly.Value.Second) : null;
        }
    }
}

#endif