using System;

namespace TaskManagement.Core.SeedWork
{
    public class Guard
    {
        public static void ForLessEqualZero(int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
        public static void ForNullOrEmpty(string value, string parameterName)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
        public static void ForContianNumber(string value, string parameterName)
        {
            if (IsStringContainNumber(value))
            {
                throw new FormatException(parameterName);
            }
        }
        public static void ForContainSpecialChar(string value, string parameterName)
        {
            if (IsContainSpecialChar(value))
            {
                throw new FormatException(parameterName);
            }
        }

        public static bool IsContainSpecialChar(string value)
        {
            foreach (var singleChar in value)
            {
                if (!Char.IsLetterOrDigit(singleChar))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool IsStringContainNumber(string value)
        {
            foreach (var singleChar in value)
            {
                if (singleChar >= '0' && singleChar <= '9')
                {
                    return true;
                }
            }

            return false;
        }

    }

}
