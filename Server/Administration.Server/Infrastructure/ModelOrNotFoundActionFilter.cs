using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Administration.Server.Infrastructure
{
    public class ModelOrNotFoundActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult {Value: null})
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
