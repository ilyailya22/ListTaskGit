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
    public class MainTasksController : ControllerBase
    {
        private readonly IRepository _repository;

        public MainTasksController()
        {
            _repository = Bootstrapper.Kernel.Get<IRepository>();
        }

        [HttpGet]
        public IEnumerable<MainTask> ReadAll()
        {
            return _repository.ReadAllMainTask();
        }

        [HttpGet("{id}")]
        public ActionResult<MainTask> ReadByld(int id)
        {
            var mainTask = _repository.ReadByldMainTask(id);

            if (mainTask == null)
            {
                return BadRequest();
            }

            return Ok(_repository.ReadByldMainTask(id));
        }

        [HttpPost]
        public ActionResult<MainTask> Post(MainTask mainTask)
        {
            if (mainTask == null)
            {
                return BadRequest();
            }

            _repository.Add(mainTask);
            return Ok(mainTask);
        }

        [HttpPut]
        public ActionResult<MainTask> Put(MainTask mainTask)
        {
            if (_repository.ReadByldMainTask(mainTask.Id) == null)
            {
                return BadRequest();
            }

            _repository.Edit(mainTask);
            return Ok(mainTask);
        }

        [HttpDelete("{id}")]
        public ActionResult<MainTask> Delete(int id)
        {
            if (_repository.ReadByldMainTask(id) == null)
            {
                return BadRequest();
            }

            _repository.Delete(id, TaskType.MainTask);
            return Ok();
        }
    }
}
