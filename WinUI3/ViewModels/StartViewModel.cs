using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml.Controls;
using turisticky_zavod.Data;
using turisticky_zavod.Logic;
using Windows.Storage;
using WinUI3.Contracts.ViewModels;
using WinUI3.Helpers;

namespace WinUI3.ViewModels;

public class StartViewModel : ObservableRecipient, INavigationAware
{
    public StartViewModel()
    {

    }

    public void OnNavigatedTo(object parameter)
    {
    }

    public void OnNavigatedFrom()
    {
    }

    public async Task<ContentDialog?> HandleFileDragDrop(IReadOnlyList<IStorageItem>? data)
    {
        var dialog = new ContentDialog
        {
            Title = "Chyba",
            CloseButtonText = "OK"
        };

        if (data != null && data.Count == 1)
        {
            var fileName = data[0].Name;
            var filePath = data[0].Path;

            var fileExtension = fileName[(fileName.LastIndexOf('.') + 1)..];

            if (fileExtension == "csv")
            {
                var runners = await FileHelper.LoadFromCSV(filePath);

                if (runners == null)
                {
                    dialog.Content = "Při načítání souboru nastala neznámá chyba";
                }
                else if (runners.All(x => x.StartNumber == null))
                {
                    dialog.Title = "Vyplnit startovní čísla";
                    dialog.Content = "Běžci nemají vyplněna startovní čísla, přejete si je automaticky vygenerovat?";
                    dialog.CloseButtonText = string.Empty;
                    dialog.PrimaryButtonText = "Ano";
                    dialog.SecondaryButtonText = "Ne";

                    await Database.Instance.Runner.AddRangeAsync(runners);
                }
            }
            else if (fileExtension == "json")
            {
                var buffer = new byte[1];
                File.OpenRead(data[0].Path).Read(buffer, 0, 1);
                var firstChar = Encoding.GetEncoding("Windows-1250").GetString(buffer);

                if (firstChar != null)
                {
                    if (firstChar == "{")
                    {
                        Database.LoadFromJson(filePath);
                    }
                    else if (firstChar == "[")
                    {
                        var runners = FileHelper.LoadRunnersFromJSON(filePath);

                        dialog.Title = "Success";
                        dialog.Content = $"Loaded {runners.Count} runners (Not really tho)";
                    }
                    else
                    {
                        dialog.Content = "Nepodporovaný formát json souboru";
                    }
                }
                else
                {
                    dialog.Content = "Při načítání souboru nastala neznámá chyba";
                }
            }
            else
            {
                dialog.Content = "Nepodporovaný formát souboru";
            }
        }
        else if (data == null || data.Count == 0)
        {
            dialog.Content = "Při načítání souboru nastala neznámá chyba";
        }
        else if (data.Count > 1)
        {
            dialog.Content = "Můžete načíst pouze jeden soubor";
        }

        return dialog;
    }

    public async void HandleEmptyStartNumbers(bool generate)
    {
        var database = Database.Instance;

        if (generate)
        {
            var numbers = database.Runner.Where(x => x.StartNumber.HasValue).ToList();
            var number = (numbers != null && numbers.Any())
                            ? numbers.MaxBy(x => x.StartNumber!.Value)!.StartNumber!.Value
                            : 0;
            foreach (var runner in database.ChangeTracker
                                           .Entries<Runner>()
                                           .Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                                           .Select(x => x.Entity)
                                           .ToList())
            {
                runner.StartNumber = ++number;
            }
        }

        await database.SaveChangesAsync();
    }
}
