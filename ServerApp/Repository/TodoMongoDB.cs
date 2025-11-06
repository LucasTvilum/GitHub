using MongoDB.Bson;
using MongoDB.Driver;
using Core.Models;
using ServerApp.Repository;

namespace WebAppAPI.repositories;

public class ToDoRepoMongoDB : ITodoRepo
{
    private string connectionString = "mongodb://localhost:27017";
    
    IMongoClient mongoClient;
    
    IMongoDatabase database;
    
    IMongoCollection<TodoItem> collection;
    
    public ToDoRepoMongoDB()
    {
        mongoClient = new MongoClient(connectionString);

        database = mongoClient.GetDatabase("tododb");
        
        collection = database.GetCollection<TodoItem>("todos");
    }

    public void Add(TodoItem todoitem)
    {
        collection.InsertOne(todoitem);
    }
    
    public TodoItem[] GetAll()
    {
        var allTodos = collection.Find(_ => true).ToList();
        return allTodos.ToArray();
    }

    public void Delete(string todoString)
    {
        Console.WriteLine("tried to delete" + todoString);
        var filter = Builders<TodoItem>.Filter.Eq(item => item.Id, todoString);
        collection.DeleteOne(filter);
    }
}