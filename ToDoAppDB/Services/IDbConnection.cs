using ToDoAppDB.Models;

namespace ToDoAppDB.Services
{
    public interface IDbConnection
    {
        Task<int> DeleteAllItemsAsync();
        Task<int> DeleteItemAsync(ToDoListModel item);
        Task<ToDoListModel> GetItemAsync(int id);
        Task<List<ToDoListModel>> GetItemsAsync();
        Task<int> SaveAllItemAsync(List<ToDoListModel> items);
        Task<int> SaveItemAsync(ToDoListModel item);
        Task<int> UpdateItemAsync(ToDoListModel item);
    }
}