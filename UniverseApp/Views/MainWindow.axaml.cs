using Avalonia.Controls;
using UniverseApp.Services;

namespace UniverseApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var service = new ZoomInOutService();
        
        KeyUp += service.OnKeyUp;
    }
}