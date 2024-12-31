using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CM4_Core.Service;
using CM4_DataAccess.Service;
using CM4_UI.Service;
using CM4_UI.ViewModels;
using CM4_UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CM4_UI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        IServiceCollection services = new ServiceCollection();
        services = ServiceCollectionDataAccessExtensions.RegisterServices(services);
        services = ServiceCollectionCoreExtensions.RegisterServices(services);
        services = ServiceCollectionUIExtensions.RegisterServices(services);

        var serviceCollection = services.BuildServiceProvider();

        var vm = serviceCollection.GetRequiredService<MainViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
