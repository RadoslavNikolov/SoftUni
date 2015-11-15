using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.App.Controllers
{
    using Data.UnitOfWork;

    public class FileController : BaseController
    {
        public FileController(ITwitterData data) 
            : base(data)
        {
        }

        public ActionResult Index(int id)
        {
            var fileToRetrieve = this.TwitterData.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}