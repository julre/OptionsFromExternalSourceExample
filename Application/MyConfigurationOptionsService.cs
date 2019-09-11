using Application.Models;
using ConfigurationSource.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class MyConfigurationOptionsService : IConfigureOptions<MyConfiguration>
    {
        private readonly ConfigurationSourceClient _client;
        private readonly ILogger _logger;

        public MyConfigurationOptionsService(
            ILogger<MyConfigurationOptionsService> logger,
            ConfigurationSourceClient client)
        {
            _logger = logger;
            _client = client;
        }

        private async Task ConfigureInternal(MyConfiguration options)
        {
            _logger.LogInformation("Configure MyConfiguration");
            try
            {
                var result = await _client.GetConfiguration();
                options.Value1 = result.Value1;
                options.Value2 = result.Value2;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "");
            }
        }

        public void Configure(MyConfiguration options)
        {
            Task.WaitAll(ConfigureInternal(options));
        }
    }
}
