using Hangfire.Annotations;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hangfire.api.Filters
{
    public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
    {

        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
