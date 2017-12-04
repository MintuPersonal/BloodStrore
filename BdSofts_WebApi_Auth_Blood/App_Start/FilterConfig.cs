using System.Web;
using System.Web.Mvc;

namespace BdSofts_WebApi_Auth_Blood
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
