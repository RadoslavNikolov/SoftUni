namespace BookShop_Web_API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using BookShopSystem.Models;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/books")]
    [Authorize]
    public class BooksController : BaseApiController
    {

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBookById(int id)
        {
            Book book = this.BookShopData.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.BadRequest("Invalid book id!");
            }

            DetailedBookViewModel result = new DetailedBookViewModel(book);

            return this.Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult SearchBook(string search)
        {
            var books = this.BookShopData.Books.Where(b => b.Title.Contains(search) || b.Description.Contains(search))
                .OrderBy(b => b.Title)
                .Take(10)
                .ToList();

            if (books.Count == 0)
            {
                return this.NotFound();
            }

            List<BookViewModel> viewModelBook = new List<BookViewModel>();

            foreach (var book in books)
            {
                viewModelBook.Add(new BookViewModel(book));
            }

            return this.Ok(viewModelBook);
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteBookById(int id)
        {
            Book book = this.BookShopData.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.BadRequest("Invalid book id!");
            }

            this.BookShopData.Books.Remove(book);
            this.BookShopData.SaveChanges();

            return this.Ok(book);
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult CreateBook([FromBody]PostBookBindingModel bookModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.BookShopData.Books.FirstOrDefault(b => b.Title == bookModel.Title) != null)
            {
                return this.Conflict();
            }

            var categories = bookModel.Categories.Split(' ').Select(c => c.Trim()).ToList();
            var categoryList= new List<Category>();

            foreach (var category in categories)
            {
                var categoryDB = this.BookShopData.Categories.FirstOrDefault(c => c.Name == category);

                if (categoryDB == null)
                {
                    categoryList.Add(new Category(){ Name = category});
                }
                else
                {
                    categoryList.Add(categoryDB);
                }
            }

            var newBook = new Book
            {
                Title = bookModel.Title,
                Description = bookModel.Decription,
                Price = bookModel.Price,
                Copies = bookModel.Copies,
                Edition = bookModel.Edition,
                AgeRestriction = bookModel.AgeRestriction,
                Categories = categoryList,
                //we need AuthorID
                AuthorId = 1
            };

            this.BookShopData.Books.Add(newBook);
            this.BookShopData.SaveChanges();

            return this.Ok(newBook);
        }


        [AllowAnonymous]
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult PutBookById([FromUri]int id, [FromBody]PutBookBindingModel bookModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            Book book = this.BookShopData.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.BadRequest("Invalid book id!");
            }

            book.Title = bookModel.Title;
            book.Description = bookModel.Decription;
            book.Price = bookModel.Price;
            book.Copies = bookModel.Copies;
            book.Edition = bookModel.Edition;
            book.AgeRestriction = bookModel.AgeRestriction;
            book.ReleaseDate = bookModel.ReleaseDate;
            book.AuthorId = bookModel.AuthorId;
            
            this.BookShopData.SaveChanges();

            return this.Ok(book);
        }


        [HttpPut]
        [Route("buy/{id}")]
        public IHttpActionResult BuyBook(int id)
        {
            var book = this.BookShopData.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            if (--book.Copies <= 0)
            {
                return this.BadRequest("There is not enough book copies.");
            }

            var loggedUserId = this.User.Identity.GetUserId();
            if (loggedUserId == null)
            {
                return this.BadRequest("Invalid session token.");
            }

            var user = this.BookShopData.Users.Find(loggedUserId);

            var purchase = new Purchase
            {
                Book = book,
                User = user,
                Price = book.Price,
                DateOfPurchase = DateTime.Now,
                IsRecalled = false
            };

            this.BookShopData.Purchases.Add(purchase);
            this.BookShopData.SaveChanges();

            return this.Ok(new PurchaseViewModel(purchase));
        }


        [HttpPut]
        [Route("recall/{id}")]
        public IHttpActionResult RecallBook(int id)
        {
            var purchase = this.BookShopData.Purchases.FirstOrDefault(p => p.Id == id);

            if (purchase == null)
            {
                return this.NotFound();
            }

            if (purchase.IsRecalled)
            {
                return this.BadRequest("Purchase already recalled.");
            }

            var dateDiff = purchase.DateOfPurchase.Date.AddDays(30) <= DateTime.Today;

            if (dateDiff)
            {
                return this.BadRequest("More than than 30 days passed since the purchase.");
            }

            purchase.Book.Copies += 1;
            purchase.IsRecalled = true;

            this.BookShopData.SaveChanges();

            return this.Ok("Purchase recalled");
        }
    }
}
