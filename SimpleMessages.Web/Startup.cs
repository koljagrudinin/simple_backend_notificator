using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleMessages.Domain.Interfaces;
using SimpleMessages.Domain.Services;
using SimpleMessages.Jobs;
using SimpleMessages.Web.Hubs;
using SimpleMessages.Web.Services;

namespace SimpleMessages.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AddServices(services);

            AddJobs(services);
            
            services.AddSignalR();

            services.AddMvc();
        }
        
        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IMessagesService, MessagesService>();
            services.AddSingleton<INotificationService, NotificationService>();
            services.AddSingleton<IMessageGeneratorService, MessageGeneratorService>();
        }

        private static void AddJobs(IServiceCollection services)
        {
            services.AddSingleton<MessageGeneratorJob>();
        }
       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSignalR(routes =>
            {
                routes.MapHub<MessagesHub>("hubs/messages");
            });

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new[] {"index.html"},
                RequestPath = new PathString()
            });

            app.UseStaticFiles();
          
            app.UseMvc(routes =>
                {
                    routes.MapRoute("default", "{controller}/{action}");

                    routes.MapRoute("Spa", "{*url}", defaults: new { controller = "Spa", action = "Spa" });
                });
        }
    }
}
