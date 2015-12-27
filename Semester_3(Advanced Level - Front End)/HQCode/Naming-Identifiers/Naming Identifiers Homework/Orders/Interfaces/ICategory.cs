namespace Orders.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface ICategory
    {
        Category GetCategoryById(int catId);

        Category GetCategoryByName(string catName);

        bool AddCategoty(Category category);

        bool RemoveCategoryById(int catId);

        bool RemoveCategory(Category category);
    }
}