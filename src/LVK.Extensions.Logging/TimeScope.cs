using System.Diagnostics;

using Microsoft.Extensions.Logging;

namespace LVK.Extensions.Logging;

internal class TimeScope : IDisposable
{
    private readonly ILogger _logger;
    private readonly string _scopeName;
    private readonly TimeSpan _threshold;
    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();

    public TimeScope(ILogger logger, string scopeName, TimeSpan threshold)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _scopeName = scopeName ?? throw new ArgumentNullException(nameof(scopeName));
        _threshold = threshold;
    }

    public void Dispose()
    {
        if (!_stopwatch.IsRunning)
            return;

        _stopwatch.Stop();
        if (_stopwatch.ElapsedMilliseconds > _threshold.TotalMilliseconds)
            _logger.LogDebug("Performance Scope {ScopeName} = {Elapsed} ms", _scopeName, _stopwatch.ElapsedMilliseconds);
    }
}