using LearningCentre.Infra.Domain.Entities;

//using Serilog;

namespace LEARNING_CENTRE_PROJECT.GlobalException
{
    public class GlobalException
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<GlobalExceptionHandlling> _logger;

        public GlobalException(RequestDelegate next)
        {
            _next = next;
        }

        public async System.Threading.Tasks.Task InvokeAsync(HttpContext context)
        {
            try
            {
                //Log.Information("");
                await _next(context);
            }
            catch (Exception exe)
            {
                //Log.Error(exe, exe.Message);

                await HandleExceptionAsync(context, exe);
            }
            //Log.CloseAndFlush();
        }

        private async System.Threading.Tasks.Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            int statusCode;

            statusCode = exception switch
            {
                AccessViolationException => StatusCodes.Status404NotFound,
                DivideByZeroException => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError,
            };

            context.Response.StatusCode = statusCode;
            //Log.Error(statusCode, exception.Message);
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = statusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}