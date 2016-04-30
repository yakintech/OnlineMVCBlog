using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class SiteMenu : BaseEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string cssClass { get; set; }
    }
}