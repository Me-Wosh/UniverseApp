using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using UniverseApp.Services;

namespace UniverseApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var service = new ZoomInOutService();
        
        KeyUp += delegate(object? sender, KeyEventArgs e)
        {
            service.OnKeyUp(sender, e);
        };
    }
}