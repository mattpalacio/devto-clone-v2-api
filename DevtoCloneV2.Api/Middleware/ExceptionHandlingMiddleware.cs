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
			catch (BadRequestCoreException ex)
			{
				var result = JsonSerializer.Serialize(new { error = ex.Message });

				context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(result);
			}
            catch (NotFoundCoreException ex)
            {
                var result = JsonSerializer.Serialize(new { error = ex.Message });

                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }
            catch (ConflictCoreException ex)
            {
                var result = JsonSerializer.Serialize(new { error = ex.Message });

                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                var result = JsonSerializer.Serialize(new { error = "Internal server error." });

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }
        }
    }
}
