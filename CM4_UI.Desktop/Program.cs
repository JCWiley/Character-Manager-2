using System;

using Avalonia;
using Avalonia.ReactiveUI;

using CM4_Extensions;

using Microsoft.Extensions.DependencyInjection;
namespace CM4_UI.Desktop;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        RegisterServices();
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();

    private static void RegisterServices()
    {
        IServiceCollection services = new ServiceCollection();
        services = ServiceCollectionExtensions.AddDataAccessServices(services);

        var serviceProvider = services.BuildServiceProvider();
    }


}
