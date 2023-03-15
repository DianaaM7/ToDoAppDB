using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoAppDB.Models;
using ToDoAppDB.Services;

namespace ToDoAppDB.ViewModels;


public partial class AddPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string _task;

    [ObservableProperty]
    private bool _isDone;

    private readonly DbConnection _dbConnection;

    public AddPageViewModel(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async void Add()
    {
        var response = await _dbConnection.SaveItemAsync(new Models.ToDoListModel
        {
            Task = Task,
            IsDone = IsDone
        });
        await GoBack();
    }


}
