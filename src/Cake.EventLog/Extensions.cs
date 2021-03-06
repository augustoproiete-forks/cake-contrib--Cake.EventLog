﻿using System;
using System.Diagnostics;
using Cake.Core;
using Cake.Core.Diagnostics;

namespace Cake.EventLog
{
    internal static class Extensions
    {
        internal static EventLogEntryType ToEntryType(this LogLevel level, Action<string> logCallback = null)
        {
            switch (level)
            {
                case LogLevel.Fatal:
                case LogLevel.Error:
                    return EventLogEntryType.Error;
                case LogLevel.Warning:
                    return EventLogEntryType.Warning;
                case LogLevel.Information:
                case LogLevel.Verbose:
                case LogLevel.Debug:
                    return EventLogEntryType.Information;
                default:
                    logCallback?.Invoke("Unexpected log level, writing as 'Information'");
                    return EventLogEntryType.Information;
            }
        }

        internal static bool IsValid(this ICakeContext ctx)
        {
            return ctx != null && ctx.Environment?.Platform?.Family == PlatformFamily.Windows;
        }

        internal static bool IsInvalid(this ICakeContext ctx)
        {
            return !ctx.IsValid();
        }
    }
}