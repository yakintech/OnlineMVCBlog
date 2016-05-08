using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.App_Start
{
    public class FilterConfig
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandledErrorLoggerFilter());
            filters.Add(new HandleErrorAttribute());
        }

        public class ElmahHandledErrorLoggerFilter : System.Web.Mvc.IExceptionFilter
        {
            public void OnException(ExceptionContext context)
            {
                if (context.ExceptionHandled)
                {
                    ErrorSignal.FromCurrentContext().Raise(context.Exception);
                }
            }
        }
    }
}