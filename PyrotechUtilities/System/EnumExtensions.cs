namespace System
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Extension methods for <see cref="System.Enum">.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the value of the Description Attribute if it exists.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns> <see cref="string"/>.</returns>
        public static string? GetDescription(this Enum value)
        {
            if (value == null)
            {
                return null;
            }

            var field = value.GetType().GetField(value.ToString());
            if (field == null)
            {
                return value.ToString();
            }

            var attribute = field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute?.Description ?? value.ToString();
        }

        /// <summary>
        /// Gets the identification value of the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The identification value of the enum value.</returns>
        public static string GetIdentification(this Enum value)
        {
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());

            if (field == null)
            {
                return value.ToString();
            }

            var attribute = field.GetCustomAttribute<IdentificationAttribute>();

            return attribute != null ? attribute.Identification : value.ToString();
        }

        /// <summary>
        /// Gets the enumerator values and descriptions.
        /// </summary>
        /// <typeparam name="T">The type of Enumerator.</typeparam>
        /// <returns>The <see cref="IEnumerable{T}"/> of enumerator values along with their descriptions.</returns>
        public static IEnumerable<EnumValueDescription> GetAllValuesAndDescriptions<T>() where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            var descriptions = new List<EnumValueDescription>(values.Length);

            foreach (T value in values)
            {
                var description = value.GetDescription();
                descriptions.Add(new EnumValueDescription { Value = value, Description = description });
            }

            return descriptions;
        }

        /// <summary>
        /// Gets the specific enum from the description.
        /// </summary>
        /// <typeparam name="T">The type of Enum.</typeparam>
        /// <param name="description">The description.</param>
        /// <returns>The enum value.</returns>
        public static T? GetEnumFromDescription<T>(this string description) where T : struct, Enum
        {
            var possibleTypes = GetAllValuesAndDescriptions<T>();
            var enumType = possibleTypes.FirstOrDefault(x => x.Description == description);

            return (T?)enumType?.Value;
        }

        /// <summary>
        /// Generic method to convert a string into it's enumeration counterpart.
        /// Uses the Description Attribute if available.
        /// </summary>
        /// <param name="key">The value.</param>
        /// <typeparam name="T">The Enumeration Type.</typeparam>
        /// <returns>The enumeration value.</returns>
        /// <exception cref="ArgumentException">Type is not an enumeration / is not valid.</exception>
        public static T GetEnum<T>(this string key) where T : struct, Enum
        {
            if (key == null || string.IsNullOrEmpty(key))
            {
                return default;
            }

            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            var values = EnumIdentificationDictionary<T>();

            if (values == null)
                return default;

            if (values.TryGetValue(key, out string? value))
            {
                return Enum.TryParse<T>(value, out var identificationResult) ? identificationResult : throw new ArgumentException("Invalid Identification");
            }

            var descriptions = EnumDescriptionDictionary<T>();

            return descriptions == null
                ? default
                : descriptions.TryGetValue(key, out string? descriptionValue)
                ? Enum.TryParse<T>(descriptionValue, out var descriptionResult) ? descriptionResult : throw new ArgumentException("Invalid Description")
                : Enum.TryParse<T>(key, out var result) ? result : throw new ArgumentException("Invalid Identification");
        }

        /// <summary>
        /// Determines if the current enumerator is in the list of acceptable values.
        /// </summary>
        /// <typeparam name="T">The type of Enumerator.</typeparam>
        /// <param name="val">The val.</param>
        /// <param name="values">The values.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool In<T>(this T val, IEnumerable<T> values) where T : struct
        {
            return values.Contains(val);
        }

        /// <summary>
        /// Gets the Enumeration Identification Dictionary. This is then used to find the corresponding enumeration.
        /// </summary>
        /// <typeparam name="T">Type of Enumeration to get dictionary for.</typeparam>
        /// <returns>Dictionary linking the Enumeration Names and the Identification Attributes.</returns>
        /// <exception cref="ArgumentException">Type provided is not an enumeration.</exception>
        private static Dictionary<string, string>? EnumIdentificationDictionary<T>()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            var values = Enum.GetValues(typeof(T));
            var en = values.Cast<T>();
            var dict = new Dictionary<string, string>();
            foreach (var t in en)
            {
                if (t is null) continue;

                var type = t.GetType();
                var name = Enum.GetName(type, t);
                if (name == null)
                {
                    continue;
                }

                var field = type.GetField(name);
                if (field == null)
                {
                    return null;
                }

                if (!Attribute.IsDefined(field, typeof(IdentificationAttribute)))
                {
                    continue;
                }

                var value = (Attribute.GetCustomAttribute(field, typeof(IdentificationAttribute)) as IdentificationAttribute)?.Identification;
                if (!dict.ContainsKey(value ?? name))
                {
                    dict.Add(value ?? name, name);
                }
            }

            return dict;
        }

        /// <summary>
        /// Gets the Enumeration Description Dictionary. This is then used to find the corresponding enumeration.
        /// </summary>
        /// <typeparam name="T">Type of Enumeration to get dictionary for.</typeparam>
        /// <returns>Dictionary linking the Enumeration Names and the Description Attributes.</returns>
        /// <exception cref="ArgumentException">Type provided is not an enumeration.</exception>
        private static Dictionary<string, string>? EnumDescriptionDictionary<T>()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }

            var values = Enum.GetValues(typeof(T));
            var en = values.Cast<T>();
            var dict = new Dictionary<string, string>();
            foreach (var t in en)
            {
                if (t is null) continue;

                var type = t.GetType();
                var name = Enum.GetName(type, t);
                if (name == null)
                {
                    continue;
                }

                var field = type.GetField(name);
                if (field == null)
                {
                    return null;
                }

                if (!Attribute.IsDefined(field, typeof(DescriptionAttribute)))
                {
                    continue;
                }

                var value = (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute)?.Description;
                if (!dict.ContainsKey(value ?? name))
                {
                    dict.Add(value ?? name, name);
                }
            }

            return dict;
        }
    }
}
