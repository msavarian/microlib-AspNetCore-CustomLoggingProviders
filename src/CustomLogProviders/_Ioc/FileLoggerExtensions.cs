using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace CustomLogProviders
{
    static public class FileLoggerExtensions
    {
        static public ILoggingBuilder AddFileLogger(this ILoggingBuilder builder)
        {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider,
                                              FileLoggerProvider>());
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton
               <IConfigureOptions<FileLoggerOptions>, FileLoggerOptionsSetup>());
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton
               <IOptionsChangeTokenSource<FileLoggerOptions>,
               LoggerProviderOptionsChangeTokenSource<FileLoggerOptions, FileLoggerProvider>>());
            return builder;
        }

        static public ILoggingBuilder AddFileLogger
               (this ILoggingBuilder builder, Action<FileLoggerOptions> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.AddFileLogger();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}