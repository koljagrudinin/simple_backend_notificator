using System;
using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleMessages.Jobs
{
    public class StructureMapJobFactory : IJobFactory
    {
        private readonly IServiceProvider _buildServiceProvider;

        public StructureMapJobFactory(IServiceProvider buildServiceProvider)
        {
            _buildServiceProvider = buildServiceProvider;
        }
        
        public IJob GetJobInstance<T>() where T : IJob
        {
            return _buildServiceProvider.GetService<T>();
        }
    }
}