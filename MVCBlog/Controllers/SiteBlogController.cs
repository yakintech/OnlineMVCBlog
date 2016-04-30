using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
using MVCBlog.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class SiteBlogController : SiteBaseController
    {
  
        public ActionResult Index(int id)
        {
            BlogPost blogpost = db.BlogPosts.FirstOrDefault(x => x.ID == id);
            SiteBlogPostVM model = new SiteBlogPostVM();
            model.Content = blogpost.Content;
            model.PostImagePath = blogpost.ImagePath;
            model.Title = blogpost.Title;
            model.Category = blogpost.Category.Name;
            model.BlogPostID = blogpost.ID;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddComment(CommentVM model)
        {
            BlogPostComment comment = new BlogPostComment();
            comment.Content = model.Content;
            comment.BlogPostID = model.BlogPostid;
            comment.Name = model.Name;
            comment.EMail = model.EMail;


            db.BlogPostComments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Index", "SiteBlog", new { id = model.BlogPostid});

        }
    }
}