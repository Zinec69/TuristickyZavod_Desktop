using Microsoft.UI.Xaml.Controls;
using WinUI3.Helpers;
using Microsoft.UI.Dispatching;
using System.Text;
using System;
using turisticky_zavod.Logic;
using Windows.ApplicationModel.DataTransfer;

namespace WinUI3;

public sealed partial class MainWindow : WindowEx
{
    public MainWindow()
    {
        InitializeComponent();

        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets/WindowIcon.ico"));
        Content = null;
        Title = "AppDisplayName".GetLocalized();
    }
}
