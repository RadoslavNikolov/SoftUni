namespace BookShop_Web_API.Models.ViewModels
{
    using BookShopSystem.Models;

    public class CategoryViewModel : CategoryNameViewModel
    {     
        public CategoryViewModel(Category category) : base(category)
        {
            this.Id = category.Id;
        }

        public int Id { get; set; }
    }
}