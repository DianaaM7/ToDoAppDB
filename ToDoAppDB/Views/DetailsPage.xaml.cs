using ToDoAppDB.ViewModels;

namespace ToDoAppDB.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}