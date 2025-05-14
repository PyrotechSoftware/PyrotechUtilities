namespace PyrotechUtilities.Tests.System;

#if NET6_0_OR_GREATER
public class TimeOnlyExtensionsTests
{
    [Fact]
    public void ToTimeOnly_FromTimeSpan_ReturnsExpectedTimeOnly()
    {
        var timeSpan = new TimeSpan(13, 45, 30);
        var expected = new TimeOnly(13, 45, 30);

        var result = timeSpan.ToTimeOnly();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToTimeOnly_FromNullableTimeSpan_ReturnsExpectedTimeOnly()
    {
        TimeSpan? timeSpan = new TimeSpan(8, 15, 0);
        var expected = new TimeOnly(8, 15, 0);

        var result = timeSpan.ToTimeOnly();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToTimeOnly_FromNullNullableTimeSpan_ReturnsNull()
    {
        TimeSpan? timeSpan = null;

        var result = timeSpan.ToTimeOnly();

        Assert.Null(result);
    }

    [Fact]
    public void ToTimeSpan_FromTimeOnly_ReturnsExpectedTimeSpan()
    {
        var timeOnly = new TimeOnly(22, 10, 5);
        var expected = new TimeSpan(22, 10, 5);

        var result = timeOnly.ToTimeSpan();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToTimeSpan_FromNullableTimeOnly_ReturnsExpectedTimeSpan()
    {
        TimeOnly? timeOnly = new TimeOnly(6, 30, 0);
        var expected = new TimeSpan(6, 30, 0);

        var result = timeOnly.ToTimeSpan();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToTimeSpan_FromNullNullableTimeOnly_ReturnsNull()
    {
        TimeOnly? timeOnly = null;

        var result = timeOnly.ToTimeSpan();

        Assert.Null(result);
    }
}
#endif
