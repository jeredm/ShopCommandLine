using System;
using System.CommandLine;
using System.Linq;

namespace ShopCommandLine
{
    public static class OptionValidationExtensions
    {
        public static Option<int> WithinRange(this Option<int> option, int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException($"{nameof(minValue)} must be <= {nameof(maxValue)}");
            }

            option.AddValidator(opt => 
                opt.Tokens
                    .Select(t => t.Value)
                    .Where(tokenValue => 
                    {
                        int value;
                        if (int.TryParse(tokenValue, out value))
                        {
                            return value < minValue || value > maxValue;
                        }
                        return true;
                    })
                    .Select(value => $"The option '{opt.Symbol.RawAliases.First()}' must be an integer between {minValue} and {maxValue}. You passed: '{value}'.")
                    .FirstOrDefault());
            return option;
        }
    }
}