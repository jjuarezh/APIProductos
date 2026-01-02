namespace ProductApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(
                    new { 
                        error = "Internal server error"
                    });
            }
        }
    }
}
