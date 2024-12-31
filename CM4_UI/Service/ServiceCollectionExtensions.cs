using CM4_Core.DataAccess;
using CM4_UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CM4_UI.Service
{
    public static class ServiceCollectionUIExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<MainViewModel>();

            return services;
        }
    }
}