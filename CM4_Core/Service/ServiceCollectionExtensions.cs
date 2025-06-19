using CM4_Core.MetaModels;
using CM4_Core.Service.Implementations;
using CM4_Core.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.Service
{
    public static class ServiceCollectionCoreExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<INotifyService, NotifyService>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<ISettingsService, SettingsService>();

            services.AddSingleton<Jobs>();
            services.AddSingleton<People>();
            return services;
        }
    }
}
