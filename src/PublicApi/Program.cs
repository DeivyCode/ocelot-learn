using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotAG.Shared.Setup.API;

var app = DefaultWebApi.Create(args, builder =>
{
    builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
    builder.Services.AddOcelot(builder.Configuration);
});
app.UseOcelot().Wait();
DefaultWebApi.Run(app);