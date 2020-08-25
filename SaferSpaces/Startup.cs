using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; //new
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SaferSpacesClient.Models;

// STARTUP WITH IDENTITY AND STARTUP FOR CLIENT SIDE ARE DIFFERENT, HOW DO WE COMBINE THEM? WHAT DO WE NEED?

namespace SaferSpacesClient
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddEntityFrameworkMySql()
      .AddDbContext<SaferSpacesClientContext>(options => options
      .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));

      //new for identity
      services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddEntityFrameworkStores<SaferSpacesClientContext>()
          .AddDefaultTokenProviders();

      // This is new:  ONLY FOR DEVELOPMENT - SET STRICTER REQUIREMENTS FOR ACTUAL LOGIN 
      services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 0;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredUniqueChars = 0;
      });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseStaticFiles();

      // app.UseDeveloperExceptionPage();
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      //new for Identity
      app.UseAuthentication();
      // app.UseHttpsRedirection();


      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}");
      });

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Something went wrong!");
      });
    }
  }
}