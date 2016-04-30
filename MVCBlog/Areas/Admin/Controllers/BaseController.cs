using MVCBlog.Areas.Admin.Models.Attributes;
using MVCBlog.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    [LoginControl]
    public class BaseController : Controller
    {
        public BlogContext db;

        public BaseController()
        {
           // ViewBag.User = HttpContext.User.Identity.Name;
            db = new BlogContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}