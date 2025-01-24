namespace CalculationProject.Api.Middleware
{
    /// <summary>
    /// Extension methods for the ErrorHandler middleware.
    /// </summary>
    public static class ErrorHandlerMiddlewareExtensions
    {
        /// <summary>
        /// Adds middleware for exception handling during HTTP request processing, logging errors, 
        /// and generating appropriate JSON responses based on encountered exceptions.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> for ErrorHandler.</returns>
        public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
