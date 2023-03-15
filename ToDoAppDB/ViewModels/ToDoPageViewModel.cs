using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoAppDB.Models;
using ToDoAppDB.Services;
using ToDoAppDB.Views;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Messaging;
using ToDoAppDB.Messages;
using CommunityToolkit.Maui.Views;
using ToDoAppDB.Popups;

namespace ToDoAppDB.ViewModels
{
    public partial class ToDoPageViewModel : BaseViewModel, IRecipient<DeleteItemMessage>
    {

        [ObservableProperty]
        List<ToDoListModel> toDos;

        [ObservableProperty]
        ToDoListModel toDo;

        [ObservableProperty]
        ToDoListModel toSaveOnDB;

        [ObservableProperty]
        private bool isDone;


        private readonly DbConnection _dbConnection;
        public ToDoPageViewModel(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            ToDos = new List<ToDoListModel>();
            ToSaveOnDB = new ToDoListModel(); // #added - instantiat modelul 
            GetInitalDataCommand.Execute(null);

            WeakReferenceMessenger.Default.Register<DeleteItemMessage>(this);

        }

        [RelayCommand]
        private async void GetInitalData()
        {
            ToDos = await _dbConnection.GetItemsAsync();
        }


        partial void OnToDoChanged(ToDoListModel value)
        {
            if (value == null) return;
            GoToMoreInfo();
        }

        [RelayCommand]
        private async void GoToMoreInfo()
        {
            var navigationParameter = new Dictionary<string, object>
            {
            { "ToDo", ToDo }
            };

            ToDo = null;

            await Shell.Current.GoToAsync(nameof(DetailsPage), navigationParameter);
        }
       
        [RelayCommand]
        private async void SaveOnDb()
        {
            await _dbConnection.SaveItemAsync(ToSaveOnDB);
            ToDos = await _dbConnection.GetItemsAsync();
        }

        [RelayCommand]
        private async void DeleteFromDb(ToDoListModel toDo)
        {
            await _dbConnection.DeleteItemAsync(toDo);
            ToDos = await _dbConnection.GetItemsAsync();
        }


        [RelayCommand]
        private async void OpenItem(ToDoListModel toDo)
        {
            var navigationParameter = new Dictionary<string, object>
            {
            { "ToDo", toDo }
            };

            await Shell.Current.GoToAsync(nameof(DetailsPage), navigationParameter);
        }


        [RelayCommand]
        public async void LoadList()
        {
            ToDos = await _dbConnection.GetItemsAsync();
        }

        [RelayCommand]
        public async void Add()
        {
            await AppShell.Current.GoToAsync(nameof(AddPage));
        }

        public void Receive(DeleteItemMessage message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                DeleteFromDbCommand.Execute(message.Value);
            });
        }
    }
}