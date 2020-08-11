namespace Trazabilidad.Helpers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// A strongly-type extension method for accessing TempData which
    /// is used to store our Alerts.
    /// </summary>
    public static class AlertExtensions
    {
        private const string Alerts = "_Alerts";

        public static List<Alert> GetAlerts(this TempDataDictionary tempData)
        {
            if (!tempData.ContainsKey(Alerts))
            {
                tempData[Alerts] = new List<Alert>();
            }

            return (List<Alert>)tempData[Alerts];
        }

        // helper methods to simplify the creation of the AlertDecoratorResult types
        public static ActionResult WithSuccess(this ActionResult result, string message, string title = "")
        {
            return new AlertDecoratorResult { InnerResult = result, Command = "success", Message = message, Title = title };
        }

        public static ActionResult WithInfo(this ActionResult result, string message, string title = "")
        {
            return new AlertDecoratorResult { InnerResult = result, Command = "info", Message = message, Title = title };
        }

        public static ActionResult WithWarning(this ActionResult result, string message, string title = "")
        {
            return new AlertDecoratorResult { InnerResult = result, Command = "warning", Message = message, Title = title };
        }

        public static ActionResult WithError(this ActionResult result, string message, string title = "")
        {
            return new AlertDecoratorResult { InnerResult = result, Command = "error", Message = message, Title = title };
        }
    }
}