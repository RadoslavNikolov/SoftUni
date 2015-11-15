using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.App.Controllers
{
    using Data;
    using Data.UnitOfWork;
    using Infrastructure;

    public class MyController : BaseController
    {
        public MyController(ITwitterData data)
            : base(data)
        {
        }
    }
}