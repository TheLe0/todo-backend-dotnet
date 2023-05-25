using System;
using System.Configuration;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Todo.Configuration;
using Todo.Application;

[assembly: FunctionsStartup(typeof(Todo.API.Startup))]
namespace Todo.API;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddConfiguration();
        builder.Services.AddApplication();
    }
}
