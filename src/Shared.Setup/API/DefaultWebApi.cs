using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OcelotAG.Shared.Setup.API;

public static class DefaultWebApi
{
    public static WebApplication Create(string[] args, Action<WebApplicationBuilder>? webappBuilder = null)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddConfiguration(HealthChecksDefaults.BuildBasicHealthCheck());
        // builder.Services.AddHealthChecks();
        // builder.Services.AddHealthChecksUI().AddInMemoryStorage();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddRouting(x => x.LowercaseUrls = true);

        if (webappBuilder != null)
        {
            webappBuilder.Invoke(builder);
        }

        return builder.Build();
    }


    public static void Run(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // app.MapHealthChecks("/health");
        //
        // app.UseHealthChecks("/health", new HealthCheckOptions()
        // {
        //     Predicate = _ => true,
        //     ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        // });
        //
        // app.UseHealthChecksUI(config => { config.UIPath = "/health-ui"; });

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
