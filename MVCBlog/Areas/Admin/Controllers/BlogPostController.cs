using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Areas.Admin.Models.Services.HTMLDataSourceServices;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class BlogPostController : BaseController
    {
        public ActionResult Index()
        {
            List<BlogPostVM> model = db.BlogPosts.Where(x => x.IsDeleted == false).OrderBy(x => x.AddDate).Select(x => new BlogPostVM()
            {
                Title = x.Title,
                CategoryName = x.Category.Name,
                ID = x.ID
            }).ToList();

            return View(model);
        }

        public ActionResult AddBlogPost()
        {
            BlogPostVM model = new BlogPostVM();
            model.drpCategories = DrpServices.getDrpCategories();


            return View(model);
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddBlogPost(BlogPostVM model)
        {
            BlogPostVM vmodel = new BlogPostVM();
            vmodel.drpCategories = DrpServices.getDrpCategories();

            if (ModelState.IsValid)
            {
                string filename = "";
                foreach (string name in Request.Files)
                {
                   
                    model.PostImage = Request.Files[name];
                    string ext = Path.GetExtension(Request.Files[name].FileName);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string uniqnumber = Guid.NewGuid().ToString();
                        filename = uniqnumber + model.PostImage.FileName;
                        model.PostImage.SaveAs(Server.MapPath("~/Areas/Admin/Content/Site/images/blogpost/" + filename));
                    }

                }

                BlogPost blogpost = new BlogPost();
                blogpost.CategoryID = model.CategoryID;
                blogpost.Title = model.Title;
                blogpost.Content = model.Content;
                blogpost.ImagePath = filename;

                db.BlogPosts.Add(blogpost);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View(vmodel);
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(vmodel);
            }

        }

        public ActionResult UpdateBlogPost(int id)
        {
            BlogPost blogpost = db.BlogPosts.FirstOrDefault(x => x.ID == id);
            BlogPostVM model = new BlogPostVM();
            model.CategoryID = blogpost.CategoryID;
            model.Title = blogpost.Title;
            model.Content = blogpost.Content;
            model.drpCategories = DrpServices.getDrpCategories();

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateBlogPost(BlogPostVM model)
        {
            model.drpCategories = DrpServices.getDrpCategories();
            if (ModelState.IsValid)
            {
                BlogPost blogpost = db.BlogPosts.FirstOrDefault(x => x.ID == model.ID);
                blogpost.CategoryID = model.CategoryID;
                blogpost.Title = model.Title;
                blogpost.Content = model.Content;

                db.SaveChanges();
                ViewBag.IslemDurum = 1;

                return View(model);
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(model);
            }

        }

        public JsonResult DeleteBlogPost(int id)
        {
            BlogPost blogpost = db.BlogPosts.FirstOrDefault(x => x.ID == id);
            blogpost.IsDeleted = true;
            blogpost.DeleteDate = DateTime.Now;
            db.SaveChanges();

            return Json("");
        }
    }
}