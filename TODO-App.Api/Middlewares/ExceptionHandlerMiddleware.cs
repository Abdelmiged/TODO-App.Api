using Domain.Exceptions.ToDoModule;
using Shared.ErrorResponse;

namespace TODO_App.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var errorResponse = new ExceptionResponse { StatusCode = StatusCodeResolver(ex), ErrorMessage = ex.Message };
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = errorResponse.StatusCode;
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }

        private int StatusCodeResolver(Exception ex)
        {
            return ex switch
            {
                ToDoCRUDException or ArgumentNullException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status404NotFound
            };
        }
    }
}
