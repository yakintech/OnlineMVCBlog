using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        {
            Database.Connection.ConnectionString = "Server=DESKTOP-I49F08P;Database=OnlineBlog; Trusted_connection=true;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<SiteMenu> SiteMenus { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }
    }
}