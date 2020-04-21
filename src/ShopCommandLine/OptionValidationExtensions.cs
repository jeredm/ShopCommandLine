using System;
using System.CommandLine;
using System.Linq;

namespace ShopCommandLine
{
    public static class OptionValidationExtensions
    {
        public static Option<T> WithinRange<T>(this Option<T> option, T minValue, T maxValue) where T : IComparable<T>, IConvertible
        {
            if (minValue is null)
            {
                throw new ArgumentNullException(nameof(minValue));
            }
            if (maxValue is null)
            {
                throw new ArgumentNullException(nameof(maxValue));
            }
            if (minValue.CompareTo(maxValue) > 0)
            {
                throw new ArgumentException($"{nameof(minValue)} must be <= {nameof(maxValue)}");
            }

            option.AddValidator(opt => 
                opt.Tokens
                    .Select(t => t.Value)
                    .Where(tokenValue => 
                    {
                        try
                        {
                            T value = (T)Convert.ChangeType(tokenValue, typeof(T));
                            Console.Write(value.CompareTo(minValue));
                            Console.WriteLine(value.CompareTo(maxValue));
                            return !(value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0);
                        }
                        catch(Exception) 
                        { 
                            return true;
                        }
                    })
                    .Select(value => $"The option '{opt.Symbol.RawAliases.First()}' must be of type '{opt.Option.ValueType}' and between '{minValue}' and '{maxValue}'. You passed: '{value}'.")
                    .FirstOrDefault());
            return option;
        }
    }
}