using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop_Web_API.Models.ViewModels
{
    using BookShopSystem.Models;

    public class CategoryNameViewModel
    {
        public string CategoryName { get; set; }

        public CategoryNameViewModel(Category category)
        {
            this.CategoryName = category.Name;
        }
    }
}