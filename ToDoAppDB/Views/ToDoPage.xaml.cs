using ToDoAppDB.Models;
using ToDoAppDB.ViewModels;
using CommunityToolkit.Maui.Views;
using ToDoAppDB.Popups;

namespace ToDoAppDB.Views;

public partial class ToDoPage : ContentPage
{
    ToDoPageViewModel toDoPageViewModel;
    public ToDoPage(ToDoPageViewModel viewModel)
    {
        InitializeComponent();
        toDoPageViewModel= viewModel;
        BindingContext = viewModel;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddPage");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        toDoPageViewModel.LoadListCommand.Execute(null);
    }

    
}