# PyrotechUtilities

A small utilities package, with some extension methods that I use all the time.

## Enum Extensions
Some useful extension methods for working with Enums.

- `[Identification]` attribute, is an attribute to be applied to an Enum value, which helps to identify the value.
  This is useful especially when using the `[Description]` attriute for the UI, and you need a clean separation between how the value is displayed and how it is identified.
- `GetIdentification()` is an extension method to get the value of the `[Identification]` attribute.
- `GetDescription()` is an extension method to get the value of the `[Description]` attribute.
- `GetEnum<T>` is an extension method for a `string` value that will attempt to get the corresponding `Enum` value.
  It will use the `[Identification]` attribute if it exists, then the `[Description]` attribute or try to just parse the value.
- `GetAllValuesAndDescriptions<T>` is an extension method to take an Enum, and create an `IEnumerable` that has the Enum value as well as the string description.
  This is particularly useful when building UI's and you need to provide the user with a Dropdown/Select of Enum values.

## DateOnly Extensions
Extensions for converting `DateTime` types to and from `DateOnly` types. (Only available from .Net 6.0)

- `ToDateTime()` will convert a `DateOnly` to a `DateTime` (works for `DateOnly?` as well)
- `ToDateOnly()` will convert a `DateTime` to a `DateOnly` (works fro `DateTime?` as well)

## Numeric Extensions
Extensions for Numeric types (int, double, decimal etc.)

- `ToFileSize()` will convert a numeric value into a string representing the file size in KB or MB
