namespace Core.Models;


    public class TodoItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "";
        public bool IsDone { get; set; }
    }

    public class TodoItemList
    {
        public List<TodoItem> items = new List<TodoItem>();
        
        public void  Add (TodoItem item)
        {
            items.Add(item);
        }
    }
