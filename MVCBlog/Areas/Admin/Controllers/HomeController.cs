using MVCBlog.Areas.Admin.Models.Attributes;
using MVCBlog.Models.ORM.Context;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    [LoginControl]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //kullanıcı ad ve soyadı login olduktan sonra aldığımız email adresi ile yakaladık

            //BlogContext db = new BlogContext();
            //string email = HttpContext.User.Identity.Name;
            //AdminUser adminuser = db.AdminUsers.FirstOrDefault(x => x.EMail == email);
            //string name = adminuser.Name;
            //string surname = adminuser.Surname;
           

            return View();
        }
    }
}