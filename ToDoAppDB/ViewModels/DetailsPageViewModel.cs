using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ToDoAppDB.Messages;
using ToDoAppDB.Models;
using ToDoAppDB.Services;

namespace ToDoAppDB.ViewModels;

[QueryProperty(nameof(ToDo),nameof(ToDo))]
public partial class DetailsPageViewModel : ObservableObject
{
    [ObservableProperty]
    ToDoListModel toDo;

    private readonly DbConnection _dbConnection;

    public DetailsPageViewModel(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    async Task Delete()
    {
        WeakReferenceMessenger.Default.Send(new DeleteItemMessage(ToDo));
        await GoBack();
    }

    [RelayCommand]
    async Task Update()
    {
        await _dbConnection.UpdateItemAsync(ToDo);
        await GoBack();
    }
}