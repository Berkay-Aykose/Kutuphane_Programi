using KutuphaneProgrami.Tasks.Triggers;
using System.Web.Mvc;
using System.Web.Routing;

namespace KutuphaneProgrami
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CezaArtirmaDusurmeTriggers.Başlat();
        }
    }
}
