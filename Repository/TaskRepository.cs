using System.Threading.Tasks;
using TaskManagerApi.Models;

namespace TaskManagerApi.Repository
{
    public class TaskRepository
    {
        private static List<TaskItem> tasks = new List<TaskItem>();
        private static int nextId = 1;

        public List<TaskItem> GetAll() => tasks;

        public TaskItem GetById(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id); 
        }

        public void Add(TaskItem task)
        {
            task.Id = nextId++;
            tasks.Add(task);
        }

        public void Update(TaskItem task)
        {
            var index = tasks.FindIndex(t => t.Id == task.Id);
            if(index != -1)
            {
                tasks[index] = task;
            }
        }

        public void Delete(int id)
        {
            var task = GetById(id);
            if (tasks != null)
            {
                tasks.Remove(task);
            }
        }

    }
}
