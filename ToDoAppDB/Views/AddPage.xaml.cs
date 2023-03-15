using ToDoAppDB.ViewModels;

namespace ToDoAppDB.Views;

public partial class AddPage : ContentPage
{
	public AddPage(AddPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}