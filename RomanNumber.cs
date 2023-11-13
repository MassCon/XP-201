using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App
{
	//public class RomanNumber
    public record RomanNumber
    {
        public int Value { get; set; }

        private const char ZERO_DIGIT = 'N';
        private const char MINUS_DIGIT = '-';
        private const char QUOTE_DIGIT = '\'';
        private const System.String INVALID_ROMAN_DIGIT = "Invalid Roman digits(s):";
        private const System.String EMPTY_INPUT_MESSAGE = "Null or empty input";
        private const System.String DIGITS_SEPARATOR = ", ";
        private const System.String ADD_NULL_MESSAGE = "Cannot Add null object";
        private const System.String NULL_MESSAGE_PATTERN = "{0}: '{1}'";
        private const System.String SUM_NULL_MESSAGE = "Invalid Sum() invocation with NULL argument";

        public RomanNumber(int value =0)
        {
            Value = value;
        }

        public static RomanNumber Parse(string input)
		{
            input = input?.Trim()!;

            CheckValidityorThrow(input);
            CheckLegalityorThrow(input);

            //if (input == "N") return new();
            if (input == ZERO_DIGIT.ToString()) return new();
            //int lastDigitIndex = input[0] == '-' ? 1 : 0;
            int lastDigitIndex = input[0] == MINUS_DIGIT ? 1 : 0;

            int prev = 0;
            int current = 0;
            int result = 0;
           
            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                current = DigitValue(input[i]);
                result += prev > current ? -current : current;
                prev = current;
            }

            //if(input == "IIX" || input =="IIV")\

            return new()
            {
                Value = result * (1 - 2 * lastDigitIndex)
            };

		}

        public override string ToString()
        {
            Dictionary<int, System.String> parts = new()
            {
                {1000 , "M" },
                {900 , "CM" },
                {500 , "D" },
                {400 , "CD" },
                {100 , "C" },
                {90 , "XC" },
                {50 , "L" },
                {40 , "XL" },
                {10 , "X" },
                {9 , "IX" },
                {5 , "V" },
                {4 , "IV" },
                {1 , "I" },
                
            };
            if (Value == 0) return ZERO_DIGIT.ToString();
            /*if (Value == 0)
            {
                return "N";
            }*/
            bool isNegative = Value < 0;

            var number = isNegative ? -Value : Value;
            StringBuilder sb = new();

            /*if (isNegative)
            {
                sb.Append('-');
            }*/
            if (isNegative) sb.Append(MINUS_DIGIT);

            foreach (var part in parts)
            {
                while(number >= part.Key)
                {
                    sb.Append(part.Value);
                    number -= part.Key;
                }
            }
            return sb.ToString();
        }
        public RomanNumber()
		{

		}


        private static int DigitValue(char digit)
        {
            return digit switch
            {
                //ZERO_DIGIT => 0,
               'N' => 0,
               'I' => 1,
               'V' => 5,
               'X' => 10,
               'L' => 50,
               'C' => 100,
               'D' => 500,
               'M' => 1000,
               _=> throw new ArgumentException($"Invalid Roman digit: '{digit}'")
               //_ => throw new ArgumentException($"{INVALID_ROMAN_DIGIT}{digit}{QUOTE_DIGIT}")
        };
        }

        private static void CheckValidityorThrow(System.String input)
        {
            if (System.String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Null or empty input");
                //throw new ArgumentException(EMPTY_INPUT_MESSAGE);
            }
            //if (input.StartsWith(MINUS_DIGIT))
            if (input.StartsWith('-'))
            {
                input = input[1..];
            }

            List<char> invalidChars = new();
            foreach (char c in input)
            {
                try { DigitValue(c); }
                catch { invalidChars.Add(c); }
            }

            if (invalidChars.Count > 0)
            {
                System.String chars = System.String.Join(", ",
                invalidChars.Select(c => $"'{c}'")
                );
                //System.String chars = System.String.Join(DIGITS_SEPARATOR, invalidChars.Select(
                //   c => $"'{QUOTE_DIGIT}{c}{QUOTE_DIGIT}'"));
                throw new ArgumentException($"Invalid Roman digits: '{chars}'");
            }
        }

        private static void CheckLegalityorThrow(System.String input)
        {
            int maxDigit = 0;
            int lessDigitCpunt = 0;
            int lastDigitIndex = input.StartsWith('-') ? 1 : 0;
            //int lastDigitIndex = input.StartsWith(MINUS_DIGIT) ? 1 : 0;

            for (int i = input.Length - 1; i >= lastDigitIndex; i--)
            {
                int digitValue = DigitValue(input[i]);


                if (digitValue < maxDigit)
                {
                    lessDigitCpunt += 1;
                    if (lessDigitCpunt > 1)
                    {
                        throw new ArgumentException(input);
                    }
                }
                else
                {
                    maxDigit = digitValue;
                    lessDigitCpunt = 0;
                }
            }
        }

        public RomanNumber Add(RomanNumber other)
        {
            //if (other is null)
            //    throw new ArgumentNullException(System.String.Format(NULL_MESSAGE_PATTERN, ADD_NULL_MESSAGE, nameof(other)));
            //return new(this.Value + other.Value);
            if (other == null)
                throw new ArgumentException($"Cannot Add null object: {nameof(other)}");
            return new ( this.Value + other.Value);
        }

        public static RomanNumber Sum(params RomanNumber[] arr_r)
        {
            if (arr_r is null)
            {
                throw new ArgumentNullException(
                    System.String.Format(
                        NULL_MESSAGE_PATTERN,
                        SUM_NULL_MESSAGE,
                        nameof(arr_r)));
            }
            int res = 0;
            foreach (var r in arr_r)
            {
                res += r.Value;
            }
            return new(res);
        }
    }

}

