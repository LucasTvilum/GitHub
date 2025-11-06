using Core.Models;
namespace ServerApp.Repository;

public class TodoRepoMemory: ITodoRepo
{
    private static List<TodoItem> TodoItems= new();

    public TodoItem[] GetAll()
    {
        return TodoItems.ToArray();
    }

    public void Add(TodoItem item)
    {
        TodoItems.Add(item);
    }
    
    public void Delete(string todoid)
    {
        TodoItems.RemoveAll(x => x.Id.ToString() == todoid);
    }
}