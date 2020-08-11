namespace Trazabilidad.Helpers
{
    using System.Web;
    using System.Web.Mvc;

    public static class ControllerHelper
    {
        public static string ControllerName(this Controller controller)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("controller"))
                return (string)routeValues["controller"];

            return string.Empty;
        }
    }
}