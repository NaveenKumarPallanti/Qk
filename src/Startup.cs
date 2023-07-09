using QuickKitchen.WebSite.Services; 
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting;

namespace QuickKitchen.WebSite
{

    ///<summary>
    /// This class represents the entry point of the ASP.NET Core application and is responsible for configuring services and 
    /// middleware components that handle incoming HTTP requests. 
    /// The ConfigureServices method is used to add various services that the application will use, such as support for Razor Pages, 
    /// server-side Blazor, HttpClient, controllers, and a custom JsonFileProductService.
    /// The Configure method is used to specify how the incoming HTTP requests should be handled. 
    /// It sets up middleware components such as error handling, HTTPS redirection, static file serving, routing, authorization, and endpoint routing. 
    /// Finally, it maps the various endpoints to Razor Pages, controllers, and server-side Blazor using the UseEndpoints method.
    ///</summary>
    public class Startup
    {

        /// Constructor method for the Startup class,
        /// which takes an IConfiguration object as a parameter and sets it to the Configuration property.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Get the Configuration
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRazorPages(); 
            services.AddServerSideBlazor(); // Add support for server-side Blazor.
            services.AddHttpClient(); // Add support for HttpClient.
            services.AddControllers(); // Add support for controllers.
            services.AddTransient<JsonFileProductService>(); // Add support for the JsonFileProductService.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {

                // Use the error handler middleware.
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Use HTTPS redirection middleware.
            app.UseHttpsRedirection();

            // Use static file serving middleware.
            app.UseStaticFiles();

            // Use routing middleware.
            app.UseRouting();

            // Use authorization middleware.
            app.UseAuthorization();

            // Use endpoint routing middleware to map endpoints to Razor Pages, controllers, and server-side Blazor.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();

                // endpoints.MapGet("/products", (context) => 
                // {
                //     var products = app.ApplicationServices.GetService<JsonFileProductService>().GetProducts();
                //     var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
                //     return context.Response.WriteAsync(json);
                // });
            });
        }
    }
}