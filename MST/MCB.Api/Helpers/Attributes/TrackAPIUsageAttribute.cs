using Microsoft.AspNetCore.Mvc.Filters;

namespace MCB.Api.Helpers.Attributes
{
    public class TrackAPIUsageAttribute : ActionFilterAttribute
    {
        public TrackAPIUsageAttribute()
        {

        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
