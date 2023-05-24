using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using turisticky_zavod.Data;
using turisticky_zavod.Logic;
using WinUI3.Contracts.ViewModels;
using WinUI3.Core.Contracts.Services;

namespace WinUI3.ViewModels;

public class ResultsViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    public ObservableCollection<Runner> Source => Database.Instance.Runner.Local.ToObservableCollection();

    public ResultsViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public void OnNavigatedTo(object parameter)
    {
        //Source.Clear();

        //// TODO: Replace with real data.
        //var data = await _sampleDataService.GetGridDataAsync();

        //foreach (var item in data)
        //{
        //    Source.Add(item);
        //}
    }

    public void OnNavigatedFrom()
    {

    }
}
