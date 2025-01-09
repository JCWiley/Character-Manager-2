using Avalonia.Controls;
using CM4_Core.DataAccess;
using CM4_UI.Menus.Implementations;
using CM4_UI.Menus.Interfaces;
using CM4_UI.ViewModels;
using CM4_UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CM4_UI.Service
{
    public static class ServiceCollectionUIExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddSingleton<IFilesService,FilesService>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MenuViewModel>();

            return services;
        }
    }
}