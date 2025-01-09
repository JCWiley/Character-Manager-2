using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CM4_Core.Service;
using CM4_DataAccess.Service;
using CM4_UI.Menus.Implementations;
using CM4_UI.Menus.Interfaces;
using CM4_UI.Service;
using CM4_UI.ViewModels;
using CM4_UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace CM4_UI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        //MainWindow MW = new MainWindow();

        IServiceCollection services = new ServiceCollection();
        services = ServiceCollectionDataAccessExtensions.RegisterServices(services);
        services = ServiceCollectionCoreExtensions.RegisterServices(services);
        services = ServiceCollectionUIExtensions.RegisterServices(services);

        var serviceCollection = services.BuildServiceProvider();

        MainWindow MW = serviceCollection.GetRequiredService<MainWindow>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = MW;
            //Debug.WriteLine("using IClassicDesktopStyleApplicationLifetime");
            serviceCollection.GetRequiredService<IFileUIService>().SetParentWindow(MW);
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            //Debug.WriteLine("using ISingleViewApplicationLifetime");
            throw new System.PlatformNotSupportedException();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
