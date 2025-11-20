namespace PyrotechUtilities.Tests.System;

using global::System.Globalization;
using FluentAssertions;

public class NumericExtensionsTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(512)]
    [InlineData(1024)]
    [InlineData(1536)]
    [InlineData(1048576)]
    [InlineData(2097152)]
    [InlineData(3145728)]
    public void ToFileSize_Int_ReturnsExpectedString_CurrentCulture(int value)
    {
        var result = value.ToFileSize(CultureInfo.CurrentCulture);
        decimal num = value / 1024m;
        decimal num2 = num / 1024m;
        var expected = !(num < 1024m)
            ? string.Format(CultureInfo.CurrentCulture, "{0:0.00} MB", num2)
            : string.Format(CultureInfo.CurrentCulture, "{0:00.00} KB", num);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1048576L)]
    [InlineData(1073741824L)]
    public void ToFileSize_Long_ReturnsExpectedString_CurrentCulture(long value)
    {
        var result = value.ToFileSize(CultureInfo.CurrentCulture);
        decimal num = value / 1024m;
        decimal num2 = num / 1024m;
        var expected = !(num < 1024m)
            ? string.Format(CultureInfo.CurrentCulture, "{0:0.00} MB", num2)
            : string.Format(CultureInfo.CurrentCulture, "{0:00.00} KB", num);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1048576, "1.00 MB")]
    [InlineData(512, "00.50 KB")]
    public void ToFileSize_Int_ReturnsExpectedString_InvariantCulture(int value, string expected)
    {
        var result = value.ToFileSize(CultureInfo.InvariantCulture);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1048576, "1,00 MB")]
    [InlineData(512, "00,50 KB")]
    public void ToFileSize_Int_ReturnsExpectedString_GermanCulture(int value, string expected)
    {
        var germanCulture = new CultureInfo("de-DE");
        var result = value.ToFileSize(germanCulture);
        result.Should().Be(expected);
    }
}
