using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCBlog.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/admincss"
                        ).Include(
                        "~/Areas/Admin/Content/css/AdminLTE.css",
                        "~/Areas/Admin/Content/css/_all-skins.min.css"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/adminjs").Include(
                "~/Scripts/jquery.slimscroll.min.js",
                "~/Scripts/fastclick.min.js",
                "~/Scripts/app.min.js",
                "~/Scripts/demo.js"
                ));


               BundleTable.EnableOptimizations = true;
        }
    }
}