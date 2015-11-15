using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Template.App.Controllers
{
    using System.Web.Http;
    using System.Web.UI;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Data.UnitOfWork;
    using Infrastructure;
    using Models;
    using Ninject.Infrastructure.Language;
    using PagedList;

    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data) : base(data)
        {
        }

        //See cache profile settings in web.config
        //[OutputCache(CacheProfile = "ClientCacheForGivenTime")]
        public ActionResult Index()
        {
            return View();
        }


        //See override method GetVaryByCustomString in Global.asax.cs
        [OutputCache(Duration = 300, VaryByCustom = "host", VaryByParam = "page")]
        public ActionResult RssFeed(int? page)
        {
            var document = XDocument.Load("https://softuni.bg/feed/news");
            var news = new HashSet<SoftUniNewsModel>();

            foreach (var childElem in document.XPathSelectElements("//item"))
            {
                var link = childElem.Element("link").Value;
                var title = childElem.Element("title").Value;
                var createdNews = new SoftUniNewsModel
                {
                    Link = link,
                    Title = title
                };
                news.Add(createdNews);
            }

            return this.PartialView("_RssFeed",news.OrderBy(n => n.Title).ToPagedList(pageNumber: page ?? 1, pageSize: AppConfig.PageSize));          
        }
    }
}