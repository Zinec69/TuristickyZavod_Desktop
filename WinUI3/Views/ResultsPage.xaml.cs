using System.ComponentModel;
using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml.Controls;
using turisticky_zavod.Data;
using turisticky_zavod.Logic;
using WinUI3.ViewModels;

namespace WinUI3.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class ResultsPage : Page
{
    public ResultsViewModel ViewModel
    {
        get;
    }

    private readonly BackgroundWorker dbLoadingWorker = new();

    public ResultsPage()
    {
        ViewModel = App.GetService<ResultsViewModel>();
        InitializeComponent();

        dbLoadingWorker.DoWork += LoadDatabaseTables;
        dbLoadingWorker.RunWorkerCompleted += DatabaseTablesLoaded;
    }

    private void Page_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        dbLoadingWorker.RunWorkerAsync();
    }

    private async void DataGrid_CellEditEnded(object sender, DataGridCellEditEndedEventArgs e)
    {
        try
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                await Database.Instance.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            DispatcherQueue.TryEnqueue(async () =>
                await new ContentDialog
                {
                    Title = "Chyba",
                    Content = $"Při editaci nastala neočekávaná chyba:\n\n{ex.Message}",
                    XamlRoot = this.XamlRoot,
                    CloseButtonText = "OK"
                }.ShowAsync()
            );
        }
    }

    private void LoadDatabaseTables(object? sender, DoWorkEventArgs e)
    {
        try
        {
            DispatcherQueue.TryEnqueue(() => LoadingControl.IsLoading = true);

            Database.Instance.LoadTables();
        }
        catch (Exception ex)
        {
            DispatcherQueue.TryEnqueue(DispatcherQueuePriority.Low, async () =>
            {
                await new ContentDialog
                {
                    Title = "Oopsies database loading",
                    Content = ex.Message,
                    CloseButtonText = "OK",
                    XamlRoot = XamlRoot
                }.ShowAsync();
            });
        }
    }

    private void DatabaseTablesLoaded(object? sender, RunWorkerCompletedEventArgs e)
    {
        dataGrid.ItemsSource ??= Database.Instance.Runner.Local.ToObservableCollection();
        DispatcherQueue.TryEnqueue(() => LoadingControl.IsLoading = false);
    }
}
