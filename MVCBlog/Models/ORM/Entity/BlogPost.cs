using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class BlogPost : BaseEntity
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryID { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        public virtual List<BlogPostComment> BlogPostComments{ get; set; }
    }
}