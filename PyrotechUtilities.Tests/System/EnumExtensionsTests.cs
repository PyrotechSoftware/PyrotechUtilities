namespace PyrotechUtilities.Tests.System;

using global::System.ComponentModel;
using FluentAssertions;

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
        TestEnum.First.GetDescription().Should().Be("First Value");
        TestEnum.Second.GetDescription().Should().Be("Second Value");
    }

    [Fact]
    public void GetDescription_ReturnsEnumNameIfNoDescription()
    {
        TestEnum.Third.GetDescription().Should().Be("Third");
    }

    [Fact]
    public void GetDescription_ReturnsNullIfValueIsNull()
    {
        Enum? value = null;
        value?.GetDescription().Should().BeNull();
    }

    [Fact]
    public void GetIdentification_ReturnsIdentificationAttributeValue()
    {
        TestEnum.First.GetIdentification().Should().Be("ID1");
        TestEnum.Second.GetIdentification().Should().Be("ID2");
    }

    [Fact]
    public void GetIdentification_ReturnsEnumNameIfNoIdentification()
    {
        TestEnum.Third.GetIdentification().Should().Be("Third");
    }

    [Fact]
    public void GetAllValuesAndDescriptions_ReturnsAllEnumValuesWithDescriptions()
    {
        var result = EnumExtensions.GetAllValuesAndDescriptions<TestEnum>();
        var list = new List<EnumValueDescription>(result);

        list.Count.Should().Be(3);
        list[0].Value.Should().Be(TestEnum.First);
        list[0].Description.Should().Be("First Value");
        list[1].Value.Should().Be(TestEnum.Second);
        list[1].Description.Should().Be("Second Value");
        list[2].Value.Should().Be(TestEnum.Third);
        list[2].Description.Should().Be("Third");
    }

    [Fact]
    public void GetEnumFromDescription_ReturnsEnumValueForDescription()
    {
        "First Value".GetEnumFromDescription<TestEnum>().Should().Be(TestEnum.First);
        "Second Value".GetEnumFromDescription<TestEnum>().Should().Be(TestEnum.Second);
    }

    [Fact]
    public void GetEnumFromDescription_ReturnsNullIfDescriptionNotFound()
    {
        "Nonexistent".GetEnumFromDescription<TestEnum>().Should().BeNull();
    }

    [Fact]
    public void GetEnum_ReturnsEnumValueForIdentification()
    {
        "ID1".GetEnum<TestEnum>().Should().Be(TestEnum.First);
        "ID2".GetEnum<TestEnum>().Should().Be(TestEnum.Second);
    }

    [Fact]
    public void GetEnum_ReturnsEnumValueForDescription()
    {
        "First Value".GetEnum<TestEnum>().Should().Be(TestEnum.First);
        "Second Value".GetEnum<TestEnum>().Should().Be(TestEnum.Second);
    }

    [Fact]
    public void GetEnum_ReturnsEnumValueForName()
    {
        "First".GetEnum<TestEnum>().Should().Be(TestEnum.First);
        "Third".GetEnum<TestEnum>().Should().Be(TestEnum.Third);
    }

    [Fact]
    public void GetEnum_ReturnsNullForNullOrEmpty()
    {
        ((string?)null)?.GetEnum<TestEnum>().Should().BeNull();
        "".GetEnum<TestEnum>().Should().BeNull();
    }

    [Fact]
    public void GetEnum_ReturnsNullForInvalidValue()
    {
        "Invalid".GetEnum<TestEnum>().Should().BeNull();
    }

    [Fact]
    public void In_ReturnsTrueIfValueInList()
    {
        var values = new[] { TestEnum.First, TestEnum.Second };
        TestEnum.First.In(values).Should().BeTrue();
        TestEnum.Second.In(values).Should().BeTrue();
    }

    [Fact]
    public void In_ReturnsFalseIfValueNotInList()
    {
        var values = new[] { TestEnum.First, TestEnum.Second };
        TestEnum.Third.In(values).Should().BeFalse();
    }

    [Fact]
    public void GetEnum_ReturnsNullForWhitespace()
    {
        " ".GetEnum<TestEnum>().Should().BeNull();
        "\t".GetEnum<TestEnum>().Should().BeNull();
        "\n".GetEnum<TestEnum>().Should().BeNull();
        "   ".GetEnum<TestEnum>().Should().BeNull();
    }
}
