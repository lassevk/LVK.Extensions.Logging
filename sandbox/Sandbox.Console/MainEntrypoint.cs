using LVK.Extensions.Bootstrapping.Console;
using LVK.Extensions.Logging;

using Microsoft.Extensions.Logging;

namespace Sandbox.Console;

public class MainEntrypoint : IMainEntrypoint
{
    private readonly ILogger<MainEntrypoint> _logger;

    public MainEntrypoint(ILogger<MainEntrypoint> logger)
    {
        _logger = logger;
    }

    public async Task<int> RunAsync(CancellationToken stoppingToken)
    {
        using IDisposable? _ = _logger.MemberScope(this);
        using (_logger.TimeScope("Test"))
        {
            await Task.Delay(1000, stoppingToken);
        }

        return 0;
    }
}