using CommunityToolkit.Maui.Views;

namespace ToDoAppDB.Popups;

public partial class EditPopup : Popup
{
    public EditPopup()
    {
        InitializeComponent();
    }

    private void Close_Button(object sender, EventArgs e)
    {
        Close();
    }
}