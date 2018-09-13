using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Services;

namespace OdeToFood
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<ICustomService, CustomService>();
			services.AddSingleton<IGreeter, Greeter>();
			services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app,
			IHostingEnvironment env,
			IGreeter greeter, ILogger<Startup> logger)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			//else
			//{
			//	app.UseExceptionHandler();
			//}

			//app.UseStaticFiles();
			//app.UseDefaultFiles();

			app.UseStaticFiles();
			//app.UseMvcWithDefaultRoute();
			//app.UseFileServer();
			app.UseMvc(ConfigureRoutes);


			app.Use(next =>
			{
				return async context =>
				{
					logger.LogInformation("requet incoming");
					if (context.Request.Path.StartsWithSegments("/mym"))
					{
						await context.Response.WriteAsync("hit!!!");
						logger.LogInformation("requet handled");
					}
					else
					{
						await next(context);
						logger.LogInformation("response outgoing");
					}
				};
			});

			app.UseWelcomePage(new WelcomePageOptions
			{
				Path = "/wp"
			});

			app.Run(async (context) =>
			{
				var greeting = greeter.GetMessageOfTheDay();
				//await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");

				context.Response.ContentType = "text/plain";
				await context.Response.WriteAsync($"not found");
			});
		}

		private void ConfigureRoutes(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute("Default",
				"{controller}/{action}/{id?}");
		}
	}
}
