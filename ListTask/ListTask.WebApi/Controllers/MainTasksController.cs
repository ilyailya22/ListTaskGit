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
            return _repository.ReadAll();
        }

        [HttpGet("{id}")]
        public ActionResult<MainTask> ReadByld(int id)
        {
            return Ok(_repository.ReadByld(id));
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
            if (mainTask == null)
            {
                return BadRequest();
            }

            _repository.Edit(mainTask);
            return Ok(mainTask);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id, TaskType.MainTask);
        }
    }
}
