using System;
using System.Linq;

namespace Convertor
{
    public static class StringToNumberConvertor
    {
        public static bool ConvertToInteger(out int result, string inputString)
        {
            result = 0;

            if (string.IsNullOrEmpty(inputString))
            {
                return false;
            }
            inputString = inputString.Trim();
            bool isNegative = inputString.StartsWith("-");
            inputString = inputString.TrimStart('-');
            inputString = inputString.TrimStart('0');

            if (inputString.ToCharArray().Any(f => f < '0' || f > '9'))
            {
                return false;
            }

            try
            {
                checked
                {
                    for (int i = inputString.Length - 1, degreeCounter = 0; i >= 0; i--, degreeCounter++)
                    {
                        result += (inputString[i] - '0')*(int) Math.Pow(10, degreeCounter);
                    }
                }
            }
            catch (OverflowException)
            {
                return false;
            }

            if (isNegative)
                result = -result;
            return true;
        }
    }
}
