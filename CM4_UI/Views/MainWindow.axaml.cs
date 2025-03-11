using Avalonia.Controls;
using CM4_UI.ViewModels;

namespace CM4_UI.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel mainViewModel)
    {
        DataContext = mainViewModel;
        InitializeComponent();
    }

    public void ApplicationAboutToClose()
    {
        (DataContext as MainViewModel)?.ApplicationAboutToClose();
    }
}
