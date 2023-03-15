using CommunityToolkit.Maui.Views;

namespace ToDoAppDB.Popups;

public partial class AddPopup : Popup
{
	public AddPopup()
	{
		InitializeComponent();
	}

	private void Close_Button(object sender, EventArgs e)
	{
		Close();
	}
}