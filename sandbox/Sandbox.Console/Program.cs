using LVK.Extensions.Bootstrapping.Console;

using Microsoft.Extensions.Hosting;

using Sandbox.Console;

await HostEx.CreateApplication<ModuleBootstrapper>(args).RunAsync();