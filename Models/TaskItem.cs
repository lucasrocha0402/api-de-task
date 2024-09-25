namespace TaskManagerApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool iscomplet { get; set; } = false;
    }
}
