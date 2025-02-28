
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace EmployeesWebApi.Models
{
    public class GlobalErrorHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ProblemDetails details = new ProblemDetails
                {
                    Status=(int)HttpStatusCode.InternalServerError,
                    Detail=ex.Message,
                    Type="Internal Server Error",
                    Title="Server Error"
                };

                //serialize the proble details into json
                var json=JsonSerializer.Serialize(details);
                //write the json error in the httpcontext response 
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}
