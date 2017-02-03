using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Tasklist.Web.Startup))]

namespace Tasklist.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            UnityConfig.RegisterComponents(config);
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
