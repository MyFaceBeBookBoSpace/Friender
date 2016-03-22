using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Friender
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            formatters.XmlFormatter.UseXmlSerializer = true;
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
