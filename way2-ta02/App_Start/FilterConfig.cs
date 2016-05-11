using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace way2_ta02
{
    [ExcludeFromCodeCoverage]
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
