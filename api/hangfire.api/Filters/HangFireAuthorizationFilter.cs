using Hangfire.Dashboard;

namespace hangfire.api.Filters
{
    public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
    {

        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}
