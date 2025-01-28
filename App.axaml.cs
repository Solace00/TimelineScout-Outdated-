using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TimeLineScoutv1.ViewModels;
using TimeLineScoutv1.Views;

namespace TimeLineScoutv1
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainWindow = new MainWindow(); // Create the MainWindow
                desktop.MainWindow = mainWindow; // Set it as the main window

                // Pass the MainWindow to the ViewModel
                mainWindow.DataContext = new MainWindowViewModel(mainWindow.VideoPlayer);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}