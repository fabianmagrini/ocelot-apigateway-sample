using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.Extensions.Logging;


namespace Gateway
{
public class Startup  
{  
    public Startup(IHostingEnvironment env)  
    {  
        var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();  
        builder.SetBasePath(env.ContentRootPath)   
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)   
               .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)  
               .AddEnvironmentVariables();  
  
        Configuration = builder.Build();  
    }  
  
    public IConfigurationRoot Configuration { get; }  
  
    public void ConfigureServices(IServiceCollection services)  
    {  
        services.AddOcelot(Configuration); 
    }  
       
    public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)  
    {  
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        await app.UseOcelot();  
    }  
} 
}
