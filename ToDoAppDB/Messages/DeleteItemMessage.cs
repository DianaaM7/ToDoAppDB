using CommunityToolkit.Mvvm.Messaging.Messages;
using ToDoAppDB.Models;

namespace ToDoAppDB.Messages;

public class DeleteItemMessage : ValueChangedMessage<ToDoListModel>
{
    public DeleteItemMessage(ToDoListModel value) : base(value)
    {
    }
}