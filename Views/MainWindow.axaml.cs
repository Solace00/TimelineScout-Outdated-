using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LibVLCSharp.Avalonia;
using TimeLineScoutv1.ViewModels;

namespace TimeLineScoutv1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            // Pass the VideoView control to the ViewModel
            var videoView = this.FindControl<VideoView>("VideoPlayer");
            DataContext = new MainWindowViewModel(videoView);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}