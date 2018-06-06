﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Ruanmou.NetCore.MVC6.Models;
using Ruanmou.NetCore.MVC6.Unitility;

namespace Ruanmou.NetCore.MVC6.Unitility.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        //private Logger logger = Logger.CreateLogger(typeof(CustomExceptionFilterAttribute));

        public CustomExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)//异常有没有被处理过
            {
                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];
                string msgTemplate = "在执行 controller[{0}] 的 action[{1}] 时产生异常";
                //logger.Error(string.Format(msgTemplate, controllerName, actionName), filterContext.Exception);

                if (this.isAjaxRequest(filterContext.HttpContext.Request))//检查请求头
                {
                    filterContext.Result = new JsonResult(
                         new AjaxResult()
                         {
                             Result = DoResult.Failed,
                             PromptMsg = "系统出现异常，请联系管理员",
                             DebugMessage = filterContext.Exception.Message
                         }//这个就是返回的结果
                    );
                }
                else
                {
                    var result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
                    result.ViewData = new ViewDataDictionary(_modelMetadataProvider, filterContext.ModelState);
                    result.ViewData.Add("Exception", filterContext.Exception);
                    filterContext.Result = result;
                }
                filterContext.ExceptionHandled = true;
            }
        }


        private bool isAjaxRequest(HttpRequest request)
        {
            string header = request.Headers["X-Requested-With"];
            return "XMLHttpRequest".Equals(header);
        }
    }
}