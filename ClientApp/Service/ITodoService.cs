using Core.Models;
namespace ClientApp.Service;


public interface ITodoService
{
    Task<TodoItem[]> GetAll();
    Task Add(TodoItem item);
    Task Delete(string id);
}