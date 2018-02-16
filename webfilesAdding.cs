export ASPNETCORE_ENVIRONMENT=Development
//**********************
// .csproj file
<ItemGroup>
  <DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="1.0.0" />
</ItemGroup>

//******************************
dotnet watch run


dotnet add package Microsoft.AspNetCore.Mvc -v=1.1
dotnet restore
//******************************
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
}
// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    loggerFactory.AddConsole();
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseMvc();
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        [HttpGetAttribute]
        public string Index()
        {
            return "Hello World!";
        }
    }
}
//Or
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
            //OR
            return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }
    }
}

//Using Static Files
dotnet add package Microsoft.AspNetCore.StaticFiles -v=1.1
public void Configure(IApplicationBuilder app)
{
    app.UseStaticFiles();
    // Other Use statements
}

//wwwroot(file name or dir) -->css(dir)-->style.css(file)

<!DOCTYPE html>
<html>
    <head>
        <meta charset='utf-8'>
        <title>Index</title>
        // In this context '~' refers to the wwwroot folder
        <link rel="stylesheet" href="~/css/style.css"/>
    </head>
    <body>
        <h1>Hello ASP.NET Mvc!</h1>
    </body>
</html>

<!DOCTYPE html>
<html>
    <head>
        <meta charset='utf-8'>
        <title>Hello!</title>
    </head>
    <body>
        <h1>Hello ASP.NET Mvc!</h1>
    </body>
</html>

//Session and TempData
dotnet add package Microsoft.AspNetCore.Session -v=1.1

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
 
namespace YourNamespace
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // Other use statements
            app.UseSession();
            
            app.UseMvc();
        }
    }
}

using Microsoft.AspNetCore.Http;


dotnet add package Microsoft.AspNet.Identity.Core --version 2.2.1


6
down vote
If you need to do the same thing but are using the new .csproj for configuration rather than the project.json, edit your .csproj file and add the following right below the propertygroup:

<PropertyGroup>
    <PackageTargetFallback>net451;dotnet5.6;portable-net45+win8</PackageTargetFallback>
</PropertyGroup>
Taken from here.

dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 1.1.3   
dotnet add package System.Data.SqlClient --version 4.4.2 



<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.5" />
    <PackageReference Include="MySql.Data" Version="7.0.7-*" />
    <PackageReference Include="System.Data.SqlClient" Version="4.4.0" />
  </ItemGroup>

  <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Tools" Version="2.0.2" />
  </ItemGroup>

</Project>