using MVCBlog.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Models.Services.HTMLDataSourceServices
{
    public class DrpServices
    {
        public static IEnumerable<SelectListItem> getDrpCategories()
        {
            using (BlogContext db = new BlogContext())
            {
                IEnumerable<SelectListItem> drpcategories = db.Categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                }).ToList();

                return drpcategories;
            }

        }
    }
}