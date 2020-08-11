using System;
using System.Web.Mvc;

namespace Trazabilidad.Helpers
{
    /// <summary>
    /// Clase para renderizar vistas
    /// </summary>
    public static class CustomRendering
    {
        /// <summary>
        /// Método extensión utilizado para renderizar vistas parciales a string. Utilizada para enviar objetos serializados a html dentro de un json.
        /// </summary>
        /// <param name="controller">Controlador que contiene la vista parcial</param>
        /// <param name="viewName">Nombre de la vista parcial. NOTA: Utilizar recursos de string</param>
        /// <param name="model">Modelo a renderizar en la vista parcial</param>
        /// <returns></returns>
        public static string RenderRazorViewToString(this Controller controller, string viewName, object model = null)
        {
            if (model != null) controller.ViewData.Model = model;

            using (var sw = new System.IO.StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}