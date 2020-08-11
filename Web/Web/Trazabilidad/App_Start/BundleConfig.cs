namespace Trazabilidad
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/custom-site").Include(
                      "~/Content/theme.css",
                      "~/Content/feather.css",
                      "~/Content/custom-style.css"
                      ));


            bundles.Add(new ScriptBundle("~/chart-config").Include(
                      "~/Scripts/chart_global.js"));


            bundles.Add(new ScriptBundle("~/maps").Include(
                      "~/Scripts/maps.js"));

           

        }
    }
}