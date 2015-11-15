using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.App.Areas.Admin.Controllers
{
    using App.Controllers;
    using Data.UnitOfWork;

    [Authorize(Roles = "Admin")]
    public class BaseAdminController : BaseController
    {
        public BaseAdminController(ITwitterData data)
            : base(data)
        {
        }
    }
}