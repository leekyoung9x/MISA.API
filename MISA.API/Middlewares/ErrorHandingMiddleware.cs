using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MISA.Core.Exceptions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MISA.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = 500;
            if (exception is CustomerException || exception is ValidateException)
            {
                code = 400;
            }
            var result = JsonConvert.SerializeObject(new { error = exception.Message });

            context.Response.StatusCode = code;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandingMiddleware>();
        }
    }
}