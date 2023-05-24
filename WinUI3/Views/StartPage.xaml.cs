using System.ComponentModel;
using System.Data;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml.Controls;
using turisticky_zavod.Data;
using turisticky_zavod.Logic;
using Windows.ApplicationModel.DataTransfer;
using WinUI3.ViewModels;

namespace WinUI3.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class StartPage : Page
{
    public StartViewModel ViewModel { get; }

    private readonly BackgroundWorker dbLoadingWorker = new();

    public StartPage()
    {
        ViewModel = App.GetService<StartViewModel>();
        InitializeComponent();

        dbLoadingWorker.DoWork += LoadDatabaseTables;
        dbLoadingWorker.RunWorkerCompleted += DatabaseTablesLoaded;
    }

    private void Page_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        dbLoadingWorker.RunWorkerAsync();
    }

    private void DataGrid_CellEditEnding(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndingEventArgs e)
    {
        
    }

    private async void DataGrid_CellEditEnded(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridCellEditEndedEventArgs e)
    {
        try
        {
            if (e.EditAction == CommunityToolkit.WinUI.UI.Controls.DataGridEditAction.Commit)
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
                    Content = $"Při editaci nastala neočekávaná chyba\n\n{ex.Message}",
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
            DispatcherQueue.TryEnqueue(() => LoadingContent.IsLoading = true);

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
        var database = Database.Instance;

        dataGrid.ItemsSource ??= database.Runner.Local.ToObservableCollection();
        teamColumn.ItemsSource ??= database.Team.Local.ToObservableCollection();
        ageCategoryColumn.ItemsSource ??= database.AgeCategory.Local.ToObservableCollection();

        DispatcherQueue.TryEnqueue(() => LoadingContent.IsLoading = false);
    }

    private void TextArea_DragOver(object sender, Microsoft.UI.Xaml.DragEventArgs e)
    {
        App.MainWindow.Activate();
        App.MainWindow.BringToFront();

        e.AcceptedOperation = DataPackageOperation.Copy;

        if (e.DataView.Contains(StandardDataFormats.StorageItems))
        {
            e.DragUIOverride.Caption = "Načíst soubor";
            e.DragUIOverride.IsGlyphVisible = true;
        }
        else
        {
            e.DragUIOverride.Caption = "Neznámý formát";
            e.DragUIOverride.IsGlyphVisible = false;
            e.Handled = true;
        }

        e.DragUIOverride.IsCaptionVisible = true;
        e.DragUIOverride.IsContentVisible = true;
    }

    private async void TextArea_Drop(object sender, Microsoft.UI.Xaml.DragEventArgs e)
    {
        if (e.Handled) return;

        var data = await e.DataView.GetStorageItemsAsync();

        DispatcherQueue.TryEnqueue(async () =>
        {
            if (await new ContentDialog
                {
                    Title = "Načíst data",
                    Content = "Opravdu chcete načíst data z csv souboru?",
                    PrimaryButtonText = "Ano",
                    SecondaryButtonText = "Ne",
                    XamlRoot = Content.XamlRoot
                }.ShowAsync() == ContentDialogResult.Primary)
            {
                var dialog = await ViewModel.HandleFileDragDrop(data);

                if (dialog != null)
                {
                    dialog.XamlRoot = Content.XamlRoot;
                    DispatcherQueue.TryEnqueue(async () =>
                    {
                        if (!string.IsNullOrEmpty(dialog.PrimaryButtonText)
                            && !string.IsNullOrEmpty(dialog.SecondaryButtonText))
                        {
                            var res = await dialog.ShowAsync() == ContentDialogResult.Primary;
                            ViewModel.HandleEmptyStartNumbers(res);
                        }
                        else
                        {
                            await dialog.ShowAsync();
                        }
                    });
                }
            }
        });

        e.Handled = true;
    }

    private void DataGrid_Sorting(object sender, CommunityToolkit.WinUI.UI.Controls.DataGridColumnEventArgs e)
    {

    }

    private void DataGrid_KeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Delete)
        {
            DispatcherQueue.TryEnqueue(async () =>
            {
                if (await new ContentDialog
                    {
                        Title = "Smazat běžce",
                        Content = "Opravdu chcete smazat tohoto běžce? Tento krok nelze vrátit zpět.",
                        PrimaryButtonText = "Ano",
                        SecondaryButtonText = "Ne",
                        XamlRoot = Content.XamlRoot
                    }.ShowAsync() == ContentDialogResult.Primary)
                {
                    var database = Database.Instance;
                    var runner = (Runner)dataGrid.SelectedItem;
                    
                    database.Runner.Local.Remove(runner);
                    await database.SaveChangesAsync();
                }
            });

            e.Handled = true;
        }
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }
}
