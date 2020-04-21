using System;
using System.CommandLine;
using FluentAssertions;
using Xunit;

namespace ShopCommandLine.Tests
{
    public class OptionValidationExtensionsTests
    {
        [Fact]
        public void WithinRange_verifies_maxValue_is_not_null()
        {
            var option = new Option<string>("-x");

            Action act = () => option.WithinRange(minValue: null, maxValue: "2");

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WithinRange_verifies_minValue_is_not_null()
        {
            var option = new Option<string>("-x");

            Action act = () => option.WithinRange(minValue: "1", maxValue: null);

            act.Should().Throw<ArgumentException>();
        }

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

        [Fact]
        public void WithinRange_works_with_decimal()
        {
            var option = new Option<decimal>("-x").WithinRange(1.0m, 10.0m);

            var command = new RootCommand { option };

            var result = command.Parse("-x 10.0");

            result.Errors
                  .Should().BeEmpty();
        }

        [Fact]
        public void WithinRange_works_with_dates()
        {
            var now = DateTime.Now;
            var option = new Option<DateTime>("-x").WithinRange(now.Date, DateTime.Now.AddDays(2).Date);

            var command = new RootCommand { option };

            var result = command.Parse($"-x \"{now}\"");

            result.Errors
                  .Should().BeEmpty();
        }
    }
}