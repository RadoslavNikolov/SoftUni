using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snippy.App.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.UnitOfWork;
    using Models.BindingModels;
    using Models.ViewModels;

    [Authorize]
    public class SnippetsController : BaseController
    {
        public SnippetsController(ISnippyData data) : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int page = 1, int count = 5)
        {
            var snippets = this.SnippyData.Snippets.All();
            int snippetsCount = snippets.Count();
            var model = snippets
                .OrderByDescending(s => s.CreatedOn)
                .Skip((page - 1) * count)
                .Take(count)
                .ProjectTo<SnippetInfoViewModel>();

            this.ViewBag.TotalPages = (snippetsCount + count - 1) / count;
            this.ViewBag.CurrentPage = page;

            return this.View(model);
        }

        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            var snippet = this.SnippyData.Snippets.All()
               .Where(s => s.Id == id)
               .ProjectTo<SnippetDetailsViewModel>()
               .FirstOrDefault();

            return this.View(snippet);
        }


        [Authorize]
        [HttpGet]
        public ActionResult My()
        {
            var userId = this.UserProfile.Id;

            var snippets = this.SnippyData.Snippets.All()
                .Where(s => s.AuthorId == userId)
                .ProjectTo<SnippetDetailsViewModel>();

            return this.View(snippets);

        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SnippetBindingModel model)
        {
            throw new NotImplementedException();
        }
       
    }
}