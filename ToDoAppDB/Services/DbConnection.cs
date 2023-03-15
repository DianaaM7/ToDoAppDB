using ToDoAppDB.Models;
using SQLite;

namespace ToDoAppDB.Services;

public class DbConnection : IDbConnection
{
    SQLiteAsyncConnection Database;

    public const SQLite.SQLiteOpenFlags Flags =
      // open the database in read/write mode
      SQLite.SQLiteOpenFlags.ReadWrite |
      // create the database if it doesn't exist
      SQLite.SQLiteOpenFlags.Create |
      // enable multi-threaded database access
      SQLite.SQLiteOpenFlags.SharedCache;

    public DbConnection()
    {
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "ToDoDb.db");

        try
        {
            Database = new SQLiteAsyncConnection(databasePath, Flags);
        }
        catch (Exception ex)
        {

        }

        await Database.CreateTableAsync<ToDoListModel>();
    }

    public async Task<List<ToDoListModel>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<ToDoListModel>().ToListAsync();
    }

    public async Task<ToDoListModel> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<ToDoListModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(ToDoListModel item)
    {
        await Init();
        return await Database.InsertAsync(item);
    }

    public async Task<int> UpdateItemAsync(ToDoListModel item)
    {
        await Init();
        return await Database.UpdateAsync(item);
    }

    public async Task<int> SaveAllItemAsync(List<ToDoListModel> items)
    {
        await Init();
        return await Database.InsertAllAsync(items);
    }

    public async Task<int> DeleteItemAsync(ToDoListModel item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    public async Task<int> DeleteAllItemsAsync()
    {
        await Init();
        return await Database.DeleteAllAsync<ToDoListModel>();
    }
}