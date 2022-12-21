using MoeSystem.Server.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace MoeSystem.Server.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went white processing {context.Request.Path}");
                await HandeExceptionAsync(context, ex);
            }
        }

        private Task HandeExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var errorDetails = new ErrorDetails();
            switch (ex)
            {
                case NotFoundException notFound:
                    statusCode = HttpStatusCode.NotFound;
                    errorDetails.Type = "Not Found";
                    errorDetails.Title = "Not Found";
                    errorDetails.Status = (int)HttpStatusCode.NotFound;
                    errorDetails.Detail = ex.Message;
                    errorDetails.Instance = ex.Source;

                    break;
                case BadRequestException badRequestException:
                    errorDetails.Type = "Bad Request";
                    errorDetails.Title = "Bad Request";
                    errorDetails.Status = (int)HttpStatusCode.BadRequest;
                    errorDetails.Detail = ex.Message;
                    errorDetails.Instance = ex.Source;

                    break;
                default:
                    errorDetails = new ErrorDetails { Detail = ex.Message, Type = ex.ToString() };
                    break;


            }

            string response = JsonConvert.SerializeObject(errorDetails);
            context.Response.StatusCode = errorDetails.Status;
            return context.Response.WriteAsync(response);



        }
    }


}
