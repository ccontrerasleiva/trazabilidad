namespace Trazabilidad.Helpers
{
    using System.Web.Mvc;

    public class AlertDecoratorResult : ActionResult
    {
        public ActionResult InnerResult { get; set; }
        public string Command { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// Uses the extension method to get the list of alerts from temp data
        /// add a new alert to this list and then hand the execution off to
        /// the innerResult
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlerts();
            alerts.Add(new Alert
            {
                Command = Command,
                Message = Message,
                Title = Title
            });
            InnerResult.ExecuteResult(context);
        }
    }
}