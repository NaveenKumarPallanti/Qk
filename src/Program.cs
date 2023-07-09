using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace QuickKitchen.WebSite
{
    public class Program
    {

        /// <summary>
        /// The Program class contains a Main method which is responsible for building and running the application. 
        /// The CreateHostBuilder method configures and builds the application's host using Host.
        /// CreateDefaultBuilder and ConfigureWebHostDefaults methods.
        /// Finally, the UseStartup method is used to specify the Startup class to be used as the starting point for the application.
        /// </summary>
        /// <param name="args">The Main method  is called when the application is started.</param>
        public static void Main(string[] args)
        {

            // the CreateHostBuilder method to create a web host and run it.
            CreateHostBuilder(args).Build().Run();
        }

        // The CreateHostBuilder method is a static method that returns an instance of IHostBuilder,
        
        // which is used to build and configure an instance of the host for the application.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) // Host.CreateDefaultBuilder(args) method creates a default host builder 
                .ConfigureWebHostDefaults(webBuilder => // ConfigureWebHostDefaults method is an extension method that configures the web host builder with the default settings for an ASP.NET Core web application.
                {
                    webBuilder.UseStartup<Startup>(); // UseStartup method specifies the Startup class that will be used to configure the application's services and middleware
                });
    }
}