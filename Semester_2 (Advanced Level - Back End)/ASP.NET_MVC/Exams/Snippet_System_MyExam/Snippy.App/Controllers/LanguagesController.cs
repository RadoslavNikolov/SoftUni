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

    public class LanguagesController : BaseController
    {
        public LanguagesController(ISnippyData data) : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var model = this.SnippyData.Snippets.All()
              .Where(s => s.Language.Id == id)
              .ProjectTo<SnippetInfoViewModel>();

            this.ViewBag.LanguageId = id;
            this.ViewBag.LanguageName = this.SnippyData.Languages.All()
                .Where(l => l.Id == id)
                .Select(x => x.Name).FirstOrDefault();

            return this.View(model);
        }

        public ActionResult GetAllLanguages(int? catId, int? selectedId)
        {
            var languages = this.SnippyData.Languages.All()
                .OrderBy(l => l.Name)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });

            return this.PartialView("Partial/_LanguagesSelect", languages);
        }
    }
}