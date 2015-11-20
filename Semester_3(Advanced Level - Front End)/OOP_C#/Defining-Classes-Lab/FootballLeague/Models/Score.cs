using FootballLeague.Helpers;

namespace FootballLeague.Models
{
    public class Score
    {
        private int homeTeamGoals;
        private int awayTeamsGoals;

        public Score(int awayTeamsGoals, int homeTeamGoals)
        {
            this.HomeTeamGoals = homeTeamGoals;
            this.AwayTeamGoals = awayTeamsGoals;
        }

        public int HomeTeamGoals
        {
            get { return this.homeTeamGoals; }
            set
            {
                CustomValidators.ValidateNumber(value);
                this.homeTeamGoals = value;
            }
        }

        public int AwayTeamGoals
        {
            get { return this.homeTeamGoals; }
            set
            {
                CustomValidators.ValidateNumber(value);
                this.homeTeamGoals = value;
            }
        }


        public int GetWinner()
        {
            int result = 0;
            if (this.AwayTeamGoals == this.HomeTeamGoals)
            {
                return result;
            }

            result = awayTeamsGoals > homeTeamGoals ? 1 : -1;

            return result;
        }           
    }
}