using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;

namespace RouletteService.Controllers
{
    // global error handler
    public static class ErrorController
    {
        public static void ErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Console.WriteLine($"##### ERROR OCCURRED: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ApiError()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = $"An API error occurred : {contextFeature.Error.Message}"
                        }.ToString());
                    }
                });
            });
        }
    }

    public class ApiError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}