namespace SportSystem.App.Models.ViewModels
{
    using System.Collections.Generic;

    public class HomaPageViewModel
    {
        public IEnumerable<MatchViewModel> MatchViewModel { get; set; }

        public IEnumerable<TeamViewModel> TeamViewModel { get; set; }
    }
}