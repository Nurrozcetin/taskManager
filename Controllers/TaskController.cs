using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Services;
using Task = TaskManager.Models.Task;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllTask();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetByIdTask(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTask = await _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.ID }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Task task)
        {
            if (id != task.ID)
                return BadRequest("Task ID mismatch.");

            var updatedTask = await _taskService.UpdateTask(task);
            if (updatedTask == null)
                return NotFound();

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _taskService.DeleteTask(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
