using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using TestAppVitalab.Services;
using TestAppVitalab.ViewModels;
using TestAppVitalab.Views;

namespace TestAppVitalab;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        Bootstrapper.Init();
        RxApp.MainThreadScheduler = AvaloniaScheduler.Instance;
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var mainViewModel = GetRequiredService<MainViewModel>(); 
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel // Use the correct variable name
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = mainViewModel // Use the correct variable name
            };
        }

        mainViewModel.Router.Navigate.Execute(GetRequiredService<LoginViewModel>()); 

        base.OnFrameworkInitializationCompleted();
    }
    private static T GetRequiredService<T>() => Splat.Locator.Current.GetRequiredService<T>();

}
