namespace PyrotechUtilities.Tests.System;

#if NET6_0_OR_GREATER
public class DateOnlyExtensionsTests
{
    [Fact]
    public void ToDateOnly_FromDateTime_ReturnsExpectedDateOnly()
    {
        var dateTime = new DateTime(2024, 6, 1, 15, 30, 45);
        var expected = new DateOnly(2024, 6, 1);

        var result = dateTime.ToDateOnly();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToDateOnly_FromNullableDateTime_ReturnsExpectedDateOnly()
    {
        DateTime? dateTime = new DateTime(2023, 12, 25, 8, 0, 0);
        var expected = new DateOnly(2023, 12, 25);

        var result = dateTime.ToDateOnly();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToDateOnly_FromNullNullableDateTime_ReturnsNull()
    {
        DateTime? dateTime = null;

        var result = dateTime.ToDateOnly();

        Assert.Null(result);
    }

    [Fact]
    public void ToDateTime_FromDateOnly_ReturnsExpectedDateTime()
    {
        var dateOnly = new DateOnly(2022, 5, 10);
        var expected = new DateTime(2022, 5, 10);

        var result = dateOnly.ToDateTime();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToDateTime_FromNullableDateOnly_ReturnsExpectedDateTime()
    {
        DateOnly? dateOnly = new DateOnly(2021, 1, 1);
        var expected = new DateTime(2021, 1, 1);

        var result = dateOnly.ToDateTime();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToDateTime_FromNullNullableDateOnly_ReturnsNull()
    {
        DateOnly? dateOnly = null;

        var result = dateOnly.ToDateTime();

        Assert.Null(result);
    }
}
#endif
