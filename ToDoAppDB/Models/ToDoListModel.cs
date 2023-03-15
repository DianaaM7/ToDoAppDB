using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace ToDoAppDB.Models;

[Table("ToDoListModel")]
public class ToDoListModel 
{

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    private string task;

    public string Task
    {
        get
        {
            return task;
        }
        set
        {
            task = value;
        }
    }

    public bool IsDone { get; set; }
}