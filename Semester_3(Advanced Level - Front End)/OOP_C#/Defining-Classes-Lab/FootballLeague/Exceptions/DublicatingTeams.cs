using System;

namespace FootballLeague.Exceptions
{
    public class DublicatingTeams : Exception
    {
        public DublicatingTeams()
       {
       }

       public DublicatingTeams(string message)
                : base(message)
       {
       }

       public DublicatingTeams(string message, Exception innerException) :
            base(message, innerException)
        {
            
        }
       
    }
}