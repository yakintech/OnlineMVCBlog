using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.VM
{
    public class CommentVM
    {
        public string Name { get; set; }

        public string EMail { get; set; }


        [Display(Name ="İçerik")]
        public string Content { get; set; }

        public int BlogPostid { get; set; }
    }
}