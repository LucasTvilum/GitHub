using Core.Models;
namespace ServerApp.Repository;


public interface ITodoRepo
{
 TodoItem[] GetAll();
 void Add(TodoItem todo);

 void Delete(string todoid);
}