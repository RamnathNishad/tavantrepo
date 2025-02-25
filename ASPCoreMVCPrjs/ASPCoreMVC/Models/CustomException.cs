using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Cryptography.Xml;

namespace ASPCoreMVC.Models
{
    public class CustomException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorMsg = context.Exception.Message;

            var result = new ViewResult
            {
                ViewName = "/Home/Error",
             };           
            
            
            result.ViewData["errorMsg"]=errorMsg;


            context.Result=result;
            context.ExceptionHandled = true;
          
        }
    }
}
