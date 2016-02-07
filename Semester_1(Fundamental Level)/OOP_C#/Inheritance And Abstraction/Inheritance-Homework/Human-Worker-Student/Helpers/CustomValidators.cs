using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Human_Worker_Student.Helpers
{
    public class CustomValidators
    {
        private static readonly Dictionary<string, int> NameConstraints = new Dictionary<string, int>()
        {
            {"human", 3},
            {"person", 3},
            {"customer", 3},
            {"product", 3},
            {"project", 3}
        };

        public static void ValidateName(string name)
        {
            // This is how i get the caller (Property setter) class name
            //That`s how i can use only one validator method for several conditions
            StackTrace stackTrace = new StackTrace();
            var className = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            var dictionaryKey = className.ToLower();
            var minNameLength = NameConstraints[dictionaryKey];

            if (string.IsNullOrWhiteSpace(name) || name.Length < minNameLength)
            {
                throw new ArgumentException(String.Format("{0} first name and {1} last name must be at least {2} characters long",
                    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(className),
                    className,
                    minNameLength));
            }
        }

        public static void ValidateFacultyNum(string value)
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentOutOfRangeException("Faculty number length must be in range[5 - 10]");
            }
        }

        public static void ValidateNumber(decimal number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Number cannot be negative");
            }
        }     
    }
}