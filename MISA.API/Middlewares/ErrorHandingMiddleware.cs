using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using MISA.Core.Exceptions;
using Newtonsoft.Json;

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

        public Task Invoke(HttpContext httpContext)
        {
            return _next(httpContext);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            var code = 500;
            if (exception is CustomerException)
            {
                code = 400;
            }
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