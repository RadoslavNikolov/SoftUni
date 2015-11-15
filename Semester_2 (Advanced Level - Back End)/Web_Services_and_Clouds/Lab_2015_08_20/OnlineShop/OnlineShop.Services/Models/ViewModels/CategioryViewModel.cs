namespace OnlineShop.Services.Models.ViewModels
{
    using OnlineShop.Models;

    public class CategioryViewModel
    {
        public CategioryViewModel()
        {
            
        }

        public CategioryViewModel(Category category)
        {
            this.Name = category.Name;
            this.Id = category.Id;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}