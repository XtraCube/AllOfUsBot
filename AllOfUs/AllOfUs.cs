using System;
using System.Threading.Tasks;
using Impostor.Api.Events.Managers;
using Impostor.Api.Plugins;
using Microsoft.Extensions.Logging;
using XtraCube.Plugins.AllOfUs.Handlers;

namespace XtraCube.Plugins.AllofUs
{
    /// <summary>
    ///     The metadata information of your plugin, this is required.
    /// </summary>
    [ImpostorPlugin(
        package: "gg.xtracube.allofus",
        name: "AllOfUs",
        author: "XtraCube",
        version: "1.0.0")]
    public class AllOfUsPlugin : PluginBase
    {
        private readonly ILogger<AllOfUsPlugin> _logger;
        // Add the line below!
        private readonly IEventManager _eventManager;
        // Add the line below!
        private IDisposable _unregister;

        public AllOfUsPlugin(ILogger<AllOfUsPlugin> logger, IEventManager eventManager)
        {
            _logger = logger;
            // Add the line below!
            _eventManager = eventManager;
        }

        public override ValueTask EnableAsync()
        {
            _logger.LogInformation("AllofUs is starting.");
            // Add the line below!
            _unregister = _eventManager.RegisterListener(new GameEventListener(_logger));
            return default;
        }

        public override ValueTask DisableAsync()
        {
            _logger.LogInformation("AllofUs is being disabled.");
            // Add the line below!
            _unregister.Dispose();
            return default;
        }
    }
}