using System;
using System.Text;
using FootballLeague.Helpers;

namespace FootballLeague.Models
{
    public class Match
    {
        private static int _instanceCounter;

        public Match(int id, Team homeTeam, Team awayTeam, int homeTeamScore, int awayteamScore)
        {
            CustomValidators.ValidateMatch(homeTeam, awayTeam);
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Score = new Score(awayteamScore, homeTeamScore);

            //Това е тъпо да се използва
            this.Id = id;

            ////По добре това. Създава се статичн брояч, който показва общият брой на инстанциите от този клас
            ////При успешното създаване на нова инстанция от този клас, броячът се увеличава и стойността се сетва на id-то
            ////Така си гарантиваме че наме да има повтаряшо се id и ще се държи като primaryKey на таблица в базата
            //_instanceCounter++;
            //this.Id = _instanceCounter;
        }


        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public Score Score { get; set; }

        public int Id { get; set; }

        public Team GetWinner
        {
            get
            {
                if (this.Score.GetWinner() == 0)
                {
                    return null;
                }

                return this.Score.GetWinner() == 1 ? this.AwayTeam : this.HomeTeam;
            }
        }

        public static int MatchesCounter
        {
            get { return Match._instanceCounter; }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("Match id: " + this.Id);
            result.AppendLine("Home team: " + this.HomeTeam.Name);
            result.AppendLine("Away team: " + this.AwayTeam.Name);
            result.AppendLine(String.Format("Match result=> {0} : {1}", this.Score.HomeTeamGoals,
                this.Score.AwayTeamGoals));

            return result.ToString();
        }
    }
}