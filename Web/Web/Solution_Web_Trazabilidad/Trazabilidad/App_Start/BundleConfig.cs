namespace Trazabilidad
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Enable Optimizations for debug mode
            //BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-datetimepicker.js"));


            #region General Page Content

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/toastr.css",
                      "~/Content/animate.css",
                      "~/Content/awesome-bootstrap-checkbox.css",
                      "~/Content/DataTables/css/jquery.dataTables.css",

                       "~/Content/pivottable-master/dist/pivot.css",
                      //"~/Content/pivottable - master/dist/pivot.min.css",

                      //"~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/Content/Site.css",
                      "~/Content/bootstrap-datetimepicker.css"));




            bundles.Add(new ScriptBundle("~/bundles/page").Include(
                       "~/Scripts/jquery.slimscroll.js",
                       "~/Scripts/metisMenu.js",
                       "~/Scripts/toastr.js",
                       "~/Scripts/custom.js",
                       "~/Scripts/pace.js",
                       "~/Scripts/configs.js",
                       "~/Scripts/getPresence.js"));

            #endregion General Page Content

            bundles.Add(new ScriptBundle("~/bundles/modal").Include(
                       "~/Scripts/modal.client.js"));

            #region Schedule Wizard

            bundles.Add(new ScriptBundle("~/bundles/schedules").Include(
                       "~/Scripts/jquery.steps.js",
                       "~/Scripts/chosen.jquery.js"));

            bundles.Add(new StyleBundle("~/Content/schedules").Include(
                      "~/Content/jquery.steps.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/bootstrap-datepicker3.css",
                      "~/Content/bootstrap-chosen.css"));

            #endregion Schedule Wizard

            bundles.Add(new ScriptBundle("~/bundles/maps").Include(
                      "~/Scripts/maps.js"));

            bundles.Add(new ScriptBundle("~/bundles/absences").Include(
                       "~/Scripts/moment.js",
                       "~/Scripts/fullcalendar.js",
                       "~/Scripts/locale-all.js",
                       "~/Scripts/absences.js"));

            bundles.Add(new ScriptBundle("~/bundles/monthlyPlan").Include(
                       "~/Scripts/moment.js",
                       "~/Scripts/fullcalendar.js",
                       "~/Scripts/locale-all.js",
                       "~/Scripts/plan.monthly.js"));


            //añadiendo datatable
            bundles.Add(new ScriptBundle("~/bundles/DTList").Include(
                     "~/Scripts/DTList.js",
                     "~/Scripts/DataTables/jquery.dataTables.js",
                     "~/Content/pivottable-master/dist/pivot.js",
                     "~/Content/pivottable-master/dist/pivot.es.js",
                     "~/Content/pivottable-master/dist/export_renderers.js"
                     //"~/Content/pivottable-master/dist/d3_renderers.js",
                     //"~/Content/pivottable-master/dist/c3_renderers.js"
                     ));

            //añadiendo grafica
            bundles.Add(new ScriptBundle("~/bundles/DTList2").Include(
                "~/Content/pivottable-master/dist/d3.min.js",
                "~/Content/pivottable-master/dist/c3.min.js",
                //"~/Content/pivottable-master/dist/pivot.min.js",
                "~/Content/pivottable-master/dist/c3_renderers.min.js"
                ));

            //añadiendo grafica
            bundles.Add(new ScriptBundle("~/bundles/DTList2_CSS").Include(
                //"~/Content/pivottable-master/dist/pivot.min.css"
                ));


            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //        "~/Content/DataTables/css/jquery.dataTables.css"
            //        ));

            //bundles.Add(new ScriptBundle("~/bundles/DTList").Include(
            //        "~/Scripts/DataTables/jquery.dataTables.js"
            //        ));

        }
    }
}