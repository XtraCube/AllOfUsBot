using Impostor.Api.Events;
using Impostor.Api.Plugins;
using XtraCube.Plugins.AllOfUs.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace XtraCube.Plugins.AOUStartup
{
    public class ExamplePluginStartup : IPluginStartup
    {
        public void ConfigureHost(IHostBuilder host)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEventListener, GameEventListener>();
        }
    }
}