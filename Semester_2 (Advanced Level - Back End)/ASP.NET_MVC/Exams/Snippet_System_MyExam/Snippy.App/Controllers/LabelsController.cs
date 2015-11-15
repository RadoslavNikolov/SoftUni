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

    public class LabelsController : BaseController
    {
        public LabelsController(ISnippyData data) : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var model = this.SnippyData.Snippets.All()
              .Where(s => s.Labels.Any(l => l.Id == id))
              .ProjectTo<SnippetInfoViewModel>();

            this.ViewBag.LabelId = id;
            this.ViewBag.LabelName = this.SnippyData.Labels.All()
                .Where(l => l.Id == id)
                .Select(x => x.Text).FirstOrDefault();

            return this.View(model);
        }
    }
}