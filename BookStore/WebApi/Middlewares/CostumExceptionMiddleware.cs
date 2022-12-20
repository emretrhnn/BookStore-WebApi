using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middleware
{
    public class CostumExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CostumExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request]  HTTP " + context.Request.Method + " - " + context.Request.Path;
                _loggerService.Write(message);

                await _next(context);
                watch.Stop();

                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " as ";
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context,watch,ex);
            }
        }

        private Task HandleException(HttpContext context, Stopwatch watch, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error]    HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " as ";
            _loggerService.Write(message);

            var result = JsonConvert.SerializeObject(new {error = ex.Message}, Formatting.None);

            return context.Response.WriteAsJsonAsync(result);
        }
    }

    public static class CostumExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCostumExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CostumExceptionMiddleware>();
        }
    }
}