using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Owin;

namespace ZQNet.Infrastructure.Owin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // Register dependencies, then...
            var container = builder.Build();

            // Register the Autofac middleware FIRST. This also adds
            // Autofac-injected middleware registered with the container.
            app.UseAutofacMiddleware(container);

            // ...then register your other middleware not registered
            // with Autofac.
        }
    }
}