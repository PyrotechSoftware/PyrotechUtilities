namespace PyrotechUtilities.Tests.System;

public class NumericExtensionsTests
{
    [Theory]
    [InlineData(0, "00.00 KB")]
    [InlineData(512, "00.50 KB")]
    [InlineData(1024, "01.00 KB")]
    [InlineData(1536, "01.50 KB")]
    [InlineData(1048576, "1.00 MB")]
    [InlineData(2097152, "2.00 MB")]
    [InlineData(3145728, "3.00 MB")]
    public void ToFileSize_Int_ReturnsExpectedString(int value, string expected)
    {
        var result = value.ToFileSize();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1048576L, "1.00 MB")]
    [InlineData(1073741824L, "1024.00 MB")]
    public void ToFileSize_Long_ReturnsExpectedString(long value, string expected)
    {
        var result = value.ToFileSize();
        Assert.Equal(expected, result);
    }
}
