using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VendingMachine.Models;
using VendingMachine.Services;
using VendingMachine.Services.Interfaces;

namespace VendingMachine
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //using dependency injection to wire up service classes
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //if there was more than one generic item for the IDataStore service, you can do the following:
            //container.Register(typeof(IDataStoreService<>), typeof(IDataStoreService<>).Assembly);
            container.Register<IDataStoreService<CoffeeModel>, InMemoryDataStoreService>(Lifestyle.Scoped);

            container.Register<IVendingMachineService, VendingMachineService>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}