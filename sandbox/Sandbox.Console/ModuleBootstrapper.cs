using LVK.Extensions.Bootstrapping;
using LVK.Extensions.Bootstrapping.Console;

using Microsoft.Extensions.Hosting;

namespace Sandbox.Console;

public class ModuleBootstrapper : IModuleBootstrapper<HostApplicationBuilder, IHost>
{
    public void Bootstrap(IHostBootstrapper<HostApplicationBuilder, IHost> bootstrapper, HostApplicationBuilder builder)
    {
        builder.Services.AddMainEntrypoint<MainEntrypoint>();
    }
}