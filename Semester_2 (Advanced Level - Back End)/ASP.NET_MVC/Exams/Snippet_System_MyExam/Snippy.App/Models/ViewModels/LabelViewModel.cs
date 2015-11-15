namespace Snippy.App.Models.ViewModels
{
    using Infrastructure.Mapping;
    using Snippy.Models;

    public class LabelViewModel : IMapFrom<Label>
    {
        public int Id { get; set; }
     
        public string Text { get; set; }


    }
}