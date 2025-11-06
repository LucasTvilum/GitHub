using System.Net.Http.Json;
using Core.Models;

namespace ClientApp.Service;

public class ToDoServiceHttp: ITodoService
{
    private HttpClient http;
    private string serverUrl = "http://localhost:5107";
    
    public ToDoServiceHttp(HttpClient client) {
        this.http = client;
    }
    public Task<TodoItem[]> GetAll()
    {
        var item =  http.GetFromJsonAsync<TodoItem[]>($"{serverUrl}/api/todos/");
        return item;
    }
    
    public async Task Add(TodoItem item) 
    {
        Console.WriteLine("meow");
    await http.PostAsJsonAsync<TodoItem>($"{serverUrl}/api/todos", item); 
    } 
    public async Task Delete(string todoid) 
    {
    await http.DeleteAsync($"{serverUrl}/api/todos/{todoid}"); 
    }
    
}