using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(Araretama.BomNaEscolaBomDeBola.Site.Startup))]
namespace Araretama.BomNaEscolaBomDeBola.Site
{
    public partial class Startup
    {
        public Configuration minhaConfiguracao { get; set; }

        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
        }
       


    }
}
