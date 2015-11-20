using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using FootballLeague.Exceptions;
using FootballLeague.Models;

namespace FootballLeague.Helpers
{
    public static class CustomValidators
    {
        private const int MinPlayerNameLength = 3;
        private const int MinTeamNameLength = 5;
        private const int MinPlayerBirthYear = 1980;
        private const int MinTeamFoudationYear = 1850;
       
        public static void ValidateNumber(int number)
        {
            if (number < 0)
            {
                throw new NegativeNumberException("Number cannot be negative");
            }
        }

        public static void ValidateMatch(Team homeTeam, Team awayTeam)
        {
            if (homeTeam.Name.ToLower().Equals(awayTeam.Name.ToLower()))
            {
                throw new DublicatingTeams("Home team and Away team must bu different");
            }
        }

        public static void ValidateName(string name)
        {
            // This is how i get the caller (Property setter) class name
            //That`s how i can use only one validator method for several conditions
            StackTrace stackTrace = new StackTrace();
            var className = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            var minNameLength = className.ToLower().Equals("team") ? MinTeamNameLength : MinPlayerNameLength;

            if (string.IsNullOrWhiteSpace(name) || name.Length < minNameLength)
            {
                throw new ArgumentException(String.Format("{0} name and {1} nick name must be at least {2} characters long", 
                    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(className), 
                    className,
                    minNameLength));
            }
        }

        public static void ValidateDate(DateTime date)
        {
            //This is how i get the caller (Property setter) class name
            //That`s how i can use only one validator method for several conditions
            //There is way to use one validator for date.Year and negative number
            StackTrace stackTrace = new StackTrace();
            var className = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            var minDateYear = className.ToLower().Equals("player") ? MinPlayerBirthYear : MinTeamFoudationYear;

            if (date.Year < minDateYear)
            {
                throw new ArgumentOutOfRangeException(String.Format("Date`s year should be after {0}", minDateYear));
            }
        }
    }
}