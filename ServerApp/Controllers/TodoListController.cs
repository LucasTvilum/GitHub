using Microsoft.AspNetCore.Mvc;
using Core.Models;
using ServerApp.Repository;

namespace ServerApp.Controllers;

[ApiController]
[Route("api/todos")]
public class TodosController : ControllerBase
{
    private ITodoRepo todoRepo;
    
    public TodosController(ITodoRepo todoRepo)
    {
        this.todoRepo = todoRepo;
    }

    [HttpGet]
    public TodoItem[] Get()
    {
        return todoRepo.GetAll();
    }
    [HttpPost]
    public void Post(TodoItem item)
    {
        todoRepo.Add(item);
    }
    [HttpDelete("{id}")]
    public void Delete(string id)
    {
        todoRepo.Delete(id);
    }
}

