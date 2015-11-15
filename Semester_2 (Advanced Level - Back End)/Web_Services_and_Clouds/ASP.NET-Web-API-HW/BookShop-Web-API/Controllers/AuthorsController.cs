using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShop_Web_API.Controllers
{
    using BookShopSystem.Data;
    using BookShopSystem.Models;
    using Microsoft.Ajax.Utilities;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/authors")]
    public class AuthorsController : BaseApiController
    {

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<AuthorAndBooksViewModel> GetAuthors()
        {
            var authors = this.BookShopData.Authors.ToList();
            List<AuthorAndBooksViewModel> viewModelAuthors = new List<AuthorAndBooksViewModel>();

            foreach (var author in authors)
            {
                viewModelAuthors.Add(new AuthorAndBooksViewModel(author));
            }

            return viewModelAuthors;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetAuthorById(int id)
        {
            Author author = this.Find(this.BookShopData, id);
            AuthorAndBooksViewModel result = new AuthorAndBooksViewModel(author);

            return this.Ok(result);
        }


        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult CreateAuthor ([FromBody]AuthorBindingModel author)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.BookShopData.Authors.FirstOrDefault(a => a.FirstName == author.FirstName && a.LastName == author.LastName) != null)
            {
                return this.Conflict();
            }

            var newAuthor = new Author()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            this.BookShopData.Authors.Add(newAuthor);
            this.BookShopData.SaveChanges();

            return this.Ok(author);
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("{id}/books")]
        public IEnumerable<DetailedBookViewModel> GetBooksByAuthor(int id)
        {
            Author author = this.Find(this.BookShopData, id);
            var books = author.Books.ToList();

            List<DetailedBookViewModel> viewModelBooks = new List<DetailedBookViewModel>();

            foreach (var book in books)
            {
                viewModelBooks.Add(new DetailedBookViewModel(book));
            }

            return viewModelBooks;
        }

        private Author Find(BookShopContext context, int id)
        {
            var author = context.Authors.FirstOrDefault(a => a.Id == id);

            return author;
        }
    }
}
