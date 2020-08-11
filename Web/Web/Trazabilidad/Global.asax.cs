namespace Trazabilidad
{
    using FluentValidation.Mvc;
    using Services.Configuration;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using ViewModels.Validations.Configurations;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new RequireHttpsAttribute());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MappingService.RegisterMappings();

            FluentValidationModelValidatorProvider.Configure(provider =>
           {
               provider.ValidatorFactory = new ValidatorFactory();
           });


        }
    }
}