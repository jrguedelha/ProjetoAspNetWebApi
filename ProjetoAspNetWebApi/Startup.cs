using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        HttpConfiguration config = new HttpConfiguration();

        var formatters = config.Formatters;
        formatters.Remove(formatters.XmlFormatter);

        var jsonSettings = formatters.JsonFormatter.SerializerSettings;
        jsonSettings.Formatting = Formatting.Indented;
        jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        jsonSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

        config.Routes.MapHttpRoute(
            name: "DefaultRoute",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        app.UseWebApi(config);
    }
}