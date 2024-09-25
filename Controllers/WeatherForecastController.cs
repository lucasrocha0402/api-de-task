using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Models;
using TaskManagerApi.Repository;

namespace TaskManagerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskRepository taskRepository = new TaskRepository();

        [HttpGet]
        public ActionResult<List<TaskItem>> GetAll() => taskRepository.GetAll();

        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetById(int id)
        {
            var task = taskRepository.GetById(id);
            if (task == null)
            {
                Console.WriteLine($"A task de id {id} não foi encontrada");
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public ActionResult<TaskItem> Create(TaskItem task)
        {
            taskRepository.Add(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskItem task)
        {
            if (id != task.Id)
                return BadRequest();
            taskRepository.Update(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            taskRepository.Delete(id);
            return NoContent();
        }
    }
}