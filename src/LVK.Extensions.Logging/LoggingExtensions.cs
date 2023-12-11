using System.Runtime.CompilerServices;

using Microsoft.Extensions.Logging;

// ReSharper disable ExplicitCallerInfoArgument

namespace LVK.Extensions.Logging;

public static class LoggingExtensions
{
    public static IDisposable TimeScope(this ILogger logger, string scopeName, TimeSpan threshold = default) => new TimeScope(logger, scopeName, threshold);

    public static IDisposable? MemberScope(
        this ILogger logger, object? instance, [CallerMemberName] string? callerMemberName = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int? callerLineNumber = null)
    {
        if (!logger.IsEnabled(LogLevel.Debug))
            return null;

        if (instance != null)
            return MemberScope(logger, instance.GetType(), callerMemberName, callerFilePath, callerLineNumber);

        return MemberScope(logger, callerMemberName, callerFilePath, callerLineNumber);
    }

    public static IDisposable? MemberScope(
        this ILogger logger, [CallerMemberName] string? callerMemberName = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int? callerLineNumber = null)
    {
        if (!logger.IsEnabled(LogLevel.Debug))
            return null;

        return logger.BeginScope($"{Path.GetFileNameWithoutExtension(callerFilePath)}.{callerMemberName} [{callerFilePath}#{callerLineNumber}]");
    }

    public static IDisposable? MemberScope<T>(
        this ILogger logger, [CallerMemberName] string? callerMemberName = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int? callerLineNumber = null)
    {
        if (!logger.IsEnabled(LogLevel.Debug))
            return null;

        return MemberScope(logger, typeof(T), callerMemberName, callerFilePath, callerLineNumber);
    }

    public static IDisposable? MemberScope(
        this ILogger logger, Type declarationType, [CallerMemberName] string? callerMemberName = null, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int? callerLineNumber = null)
    {
        if (!logger.IsEnabled(LogLevel.Debug))
            return null;

        return logger.BeginScope($"{declarationType.FullName}.{callerMemberName} [{callerFilePath}#{callerLineNumber}]");
    }
}