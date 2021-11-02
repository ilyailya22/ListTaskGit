using System.Collections.Generic;
using System.Linq;
using ListTask.Models;
using ListTask.Repository;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace ListTask.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubTasksController : ControllerBase
    {
        private readonly IRepository _repository;

        public SubTasksController()
        {
            _repository = Bootstrapper.Kernel.Get<IRepository>();
        }

        [HttpGet]
        public IEnumerable<SubTask> ReadAll()
        {
            return _repository.ReadAllSubTask();
        }

        [HttpGet("{id}")]
        public ActionResult<SubTask> ReadByld(int id)
        {
            return Ok(_repository.ReadByldSubTask(id));
        }

        [HttpPost]
        public ActionResult<SubTask> Post(SubTask subTask)
        {
            if (subTask == null)
            {
                return BadRequest();
            }

            _repository.Add(subTask);
            return Ok(subTask);
        }

        [HttpPut]
        public ActionResult<SubTask> Put(SubTask subTask)
        {
            if (subTask == null)
            {
                return BadRequest();
            }

            _repository.Edit(subTask);
            return Ok(subTask);
        }

        [HttpDelete("{id}")]
        public ActionResult<SubTask> Delete(int id)
        {
            SubTask subtask = _repository.ReadByldSubTask(id);
            _repository.Delete(id, TaskType.SubTask);
            return Ok(subtask);
        }
    }
}
