using Avalonia.Controls;
using CM4_Core.DataAccess;
using CM4_UI.Menus.Implementations;
using CM4_UI.Menus.Interfaces;
using CM4_UI.ObservableModels;
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
            services.AddSingleton<IFileUIService,FileUIService>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<MenuViewModel>();
            services.AddTransient<OrgTreeViewModel>();
            services.AddTransient<TabViewModel>();
            services.AddTransient<OrganizationDetailViewModel>();
            services.AddTransient<CharacterDetailViewModel>();

            services.AddSingleton<PeopleViewModel>();
            services.AddSingleton<WorldDataViewModel>();

            return services;
        }
    }
}