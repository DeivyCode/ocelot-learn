using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace OcelotAG.Shared.Setup.API;

public static class HealthChecksDefaults
{
    public static IConfiguration BuildBasicHealthCheck()
    {
        var myConfiguration = new Dictionary<string, string>
        {
            { "HealthChecksUI:HealthChecks:0:Name", "self" },
            { "HealthChecksUI:HealthChecks:0:Uri", "/health" },
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(myConfiguration)
            .Build();
    }
}