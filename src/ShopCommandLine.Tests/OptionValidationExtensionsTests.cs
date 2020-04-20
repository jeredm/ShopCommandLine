using System;
using System.CommandLine;
using FluentAssertions;
using Xunit;

namespace ShopCommandLine.Tests
{
    public class OptionValidationExtensionsTests
    {
        [Fact]
        public void WithinRange_verifies_maxValue_is_after_minValue()
        {
            var option = new Option<int>("-x");

            Action act = () => option.WithinRange(minValue: 100, maxValue: 1);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WithinRange_generates_an_error_when_the_value_is_less_than_minValue()
        {
            var option = new Option<int>("-x").WithinRange(1, 10);

            var command = new RootCommand { option };

            var result = command.Parse("-x 0");

            result.Errors
                  .Should()
                  .ContainSingle(e => e.SymbolResult.Symbol == option);
        }

        [Fact]
        public void WithinRange_generates_an_error_when_the_value_is_more_than_maxValue()
        {
            var option = new Option<int>("-x").WithinRange(1, 10);

            var command = new RootCommand { option };

            var result = command.Parse("-x 11");

            result.Errors
                  .Should()
                  .ContainSingle(e => e.SymbolResult.Symbol == option);
        }

        [Fact]
        public void WithinRange_generates_an_error_when_the_value_is_not_an_int()
        {
            var option = new Option<int>("-x").WithinRange(1, 10);

            var command = new RootCommand { option };

            var result = command.Parse("-x 5.5");

            result.Errors
                  .Should()
                  .ContainSingle(e => e.SymbolResult.Symbol == option);
        }

        [Fact]
        public void WithinRange_is_inclusive_of_minValue()
        {
            var option = new Option<int>("-x").WithinRange(1, 10);

            var command = new RootCommand { option };

            var result = command.Parse("-x 1");

            result.Errors
                  .Should().BeEmpty();
        }

        [Fact]
        public void WithinRange_is_inclusive_of_maxValue()
        {
            var option = new Option<int>("-x").WithinRange(1, 10);

            var command = new RootCommand { option };

            var result = command.Parse("-x 10");

            result.Errors
                  .Should().BeEmpty();
        }
    }
}