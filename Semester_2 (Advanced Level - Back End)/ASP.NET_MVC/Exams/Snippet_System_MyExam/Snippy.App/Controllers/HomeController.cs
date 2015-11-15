using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snippy.App.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Data.UnitOfWork;
    using Models.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var model = new HomePageViewModel();
            var snippetModel = this.SnippyData.Snippets.All()
                .OrderByDescending(s => s.CreatedOn)
                .Take(5)
                .ProjectTo<SnippetInfoViewModel>();

            var commentModel = this.SnippyData.Comments.All()
                .OrderByDescending(c => c.CreatedOn)
                .Take(5)
                .ProjectTo<CommentViewModel>();

            var labelModel = this.SnippyData.Labels.All()
                .OrderByDescending(l => l.Snippets.Count)
                .Take(5)
                .ProjectTo<LabelInfoViewModel>();

            model.SnippetInfoViewModel = snippetModel;
            model.CommentViewModel = commentModel;
            model.LabelInfoViewModel = labelModel;

            return View(model);
        }

    }
}