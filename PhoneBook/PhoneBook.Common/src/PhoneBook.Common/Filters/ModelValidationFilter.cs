using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PhoneBook.Common.Types;

namespace PhoneBook.Common.Filters
{
    public class ModelValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (!filterContext.ModelState.IsValid)
            {
                if (filterContext.HttpContext.Request.Method == "GET")
                {
                    var result = new BadRequestResult();
                    filterContext.Result = result;
                }
                else
                {
                    var content = new ApiError(filterContext.ModelState);
                    var result = new JsonResult(content);
                    result.ContentType = "application/json";

                    filterContext.HttpContext.Response.StatusCode = 400;
                    filterContext.Result = result;
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

    }
}