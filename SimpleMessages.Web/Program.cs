using System;
using FluentScheduler;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SimpleMessages.Jobs;

namespace SimpleMessages.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            ConfigureJobs(host.Services);
            
            host.Run();
        }

        internal static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        
        
        internal static void ConfigureJobs(IServiceProvider serviceProvider)
        {
            JobManager.JobFactory = new StructureMapJobFactory(serviceProvider);

            JobManager.JobException += info =>
                Console.Out.WriteLine("Error with job: " + info.Exception.Message);

            JobManager.Initialize(new JobRegistry());
        }

    }
}
