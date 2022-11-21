using DevtoCloneV2.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace DevtoCloneV2.Api.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = exception switch
            {
                BadRequestCoreException => (int)HttpStatusCode.BadRequest,
                NotFoundCoreException => (int)HttpStatusCode.NotFound,
                ConflictCoreException => (int)HttpStatusCode.Conflict,
                UnprocessableEntityCoreException => (int)HttpStatusCode.UnprocessableEntity,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(new { error = httpContext.Response.StatusCode < 500 ? exception.Message : "Internal server error." });
            await httpContext.Response.WriteAsync(result);
        }
    }
}
