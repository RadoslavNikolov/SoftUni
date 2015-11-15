namespace BookShop_Web_API.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using BookShopSystem.Data;
    using BookShopSystem.Models;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/categories")]
    public class CategoriesController : BaseApiController
    {

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            var categories = this.BookShopData.Categories;

            if (categories == null)
            {
                return this.NotFound();
            }

            List<CategoryViewModel> viewModelCategories = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                viewModelCategories.Add(new CategoryViewModel(category));
            }

            return this.Ok(viewModelCategories);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCategiryById([FromUri] int id)
        {
            var category = this.BookShopData.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return this.NotFound();
            }

            CategoryViewModel result = new CategoryViewModel(category);

            return this.Ok(result);
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult PutCategoryById([FromUri]int id, [FromBody]CategoryBindingModel categoryModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var category = this.BookShopData.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            var dublicate = this.BookShopData.Categories.FirstOrDefault(c => c.Name == categoryModel.Name);

            if (dublicate != null)
            {
                return this.Conflict();
            }

            category.Name = categoryModel.Name;
            this.BookShopData.SaveChanges();

            return this.Ok(new CategoryNameViewModel(category));
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCategoryById(int id)
        {
            var category = this.BookShopData.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            this.BookShopData.Categories.Remove(category);
            this.BookShopData.SaveChanges();

            return this.Ok(category);
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult PostCategory([FromBody]CategoryBindingModel categoryModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var category = this.BookShopData.Categories.FirstOrDefault(c => c.Name == categoryModel.Name);

            if (category != null)
            {
                return this.Conflict();
            }

            category = new Category(){Name = categoryModel.Name};
            this.BookShopData.Categories.Add(category);
            this.BookShopData.SaveChanges();

            return this.Ok(new CategoryNameViewModel(category));
        }
    }
}
