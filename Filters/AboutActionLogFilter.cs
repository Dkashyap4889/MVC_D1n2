using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC_Assignment.Filters
{
    public class AboutActionLogFilter : IActionFilter
    {
        private readonly ILogger<AboutActionLogFilter> _logger;

        public AboutActionLogFilter(ILogger<AboutActionLogFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("About action executing.");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
