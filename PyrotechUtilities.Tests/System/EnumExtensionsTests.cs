namespace PyrotechUtilities.Tests.System;

using global::System.ComponentModel;

public class EnumExtensionsTests
{
    private enum TestEnum
    {
        [Description("First Value")]
        [Identification("ID1")]
        First,

        [Description("Second Value")]
        [Identification("ID2")]
        Second,

        Third // No attributes
    }

    [Fact]
    public void GetDescription_ReturnsDescriptionAttributeValue()
    {
        Assert.Equal("First Value", TestEnum.First.GetDescription());
        Assert.Equal("Second Value", TestEnum.Second.GetDescription());
    }

    [Fact]
    public void GetDescription_ReturnsEnumNameIfNoDescription()
    {
        Assert.Equal("Third", TestEnum.Third.GetDescription());
    }

    [Fact]
    public void GetDescription_ReturnsNullIfValueIsNull()
    {
        Enum? value = null;
        Assert.Null(value?.GetDescription());
    }

    [Fact]
    public void GetIdentification_ReturnsIdentificationAttributeValue()
    {
        Assert.Equal("ID1", TestEnum.First.GetIdentification());
        Assert.Equal("ID2", TestEnum.Second.GetIdentification());
    }

    [Fact]
    public void GetIdentification_ReturnsEnumNameIfNoIdentification()
    {
        Assert.Equal("Third", TestEnum.Third.GetIdentification());
    }

    [Fact]
    public void GetAllValuesAndDescriptions_ReturnsAllEnumValuesWithDescriptions()
    {
        var result = EnumExtensions.GetAllValuesAndDescriptions<TestEnum>();
        var list = new List<EnumValueDescription>(result);

        Assert.Equal(3, list.Count);
        Assert.Equal(TestEnum.First, list[0].Value);
        Assert.Equal("First Value", list[0].Description);
        Assert.Equal(TestEnum.Second, list[1].Value);
        Assert.Equal("Second Value", list[1].Description);
        Assert.Equal(TestEnum.Third, list[2].Value);
        Assert.Equal("Third", list[2].Description);
    }

    [Fact]
    public void GetEnumFromDescription_ReturnsEnumValueForDescription()
    {
        Assert.Equal(TestEnum.First, "First Value".GetEnumFromDescription<TestEnum>());
        Assert.Equal(TestEnum.Second, "Second Value".GetEnumFromDescription<TestEnum>());
    }

    [Fact]
    public void GetEnumFromDescription_ReturnsNullIfDescriptionNotFound()
    {
        Assert.Null("Nonexistent".GetEnumFromDescription<TestEnum>());
    }

    [Fact]
    public void GetEnum_ReturnsEnumValueForIdentification()
    {
        Assert.Equal(TestEnum.First, "ID1".GetEnum<TestEnum>());
        Assert.Equal(TestEnum.Second, "ID2".GetEnum<TestEnum>());
    }

    [Fact]
    public void GetEnum_ReturnsEnumValueForDescription()
    {
        Assert.Equal(TestEnum.First, "First Value".GetEnum<TestEnum>());
        Assert.Equal(TestEnum.Second, "Second Value".GetEnum<TestEnum>());
    }

    [Fact]
    public void GetEnum_ReturnsEnumValueForName()
    {
        Assert.Equal(TestEnum.First, "First".GetEnum<TestEnum>());
        Assert.Equal(TestEnum.Third, "Third".GetEnum<TestEnum>());
    }

    [Fact]
    public void GetEnum_ReturnsDefaultForNullOrEmpty()
    {
        Assert.Equal(default, ((string?)null)?.GetEnum<TestEnum>());
        Assert.Equal(default, "".GetEnum<TestEnum>());
    }

    [Fact]
    public void GetEnum_ThrowsArgumentExceptionForInvalidValue()
    {
        Assert.Throws<ArgumentException>(() => "Invalid".GetEnum<TestEnum>());
    }

    [Fact]
    public void In_ReturnsTrueIfValueInList()
    {
        var values = new[] { TestEnum.First, TestEnum.Second };
        Assert.True(TestEnum.First.In(values));
        Assert.True(TestEnum.Second.In(values));
    }

    [Fact]
    public void In_ReturnsFalseIfValueNotInList()
    {
        var values = new[] { TestEnum.First, TestEnum.Second };
        Assert.False(TestEnum.Third.In(values));
    }
}
