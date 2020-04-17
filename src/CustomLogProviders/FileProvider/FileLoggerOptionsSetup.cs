using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace CustomLogProviders
{
    internal class FileLoggerOptionsSetup : ConfigureFromConfigurationOptions<FileLoggerOptions>
    {
        public FileLoggerOptionsSetup(ILoggerProviderConfiguration<FileLoggerProvider>
                                      providerConfiguration)
            : base(providerConfiguration.Configuration)
        {
        }
    }

}
