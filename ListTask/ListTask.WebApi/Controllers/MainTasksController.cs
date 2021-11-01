using System.Collections.Generic;
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
            var bootstrapper = new Bootstrapper();
            _repository = Bootstrapper.Kernel.Get<IRepository>();
        }

        [HttpGet]
        public IEnumerable<BaseTask> GetAllTasks()
        {
            return _repository.GetAllTasks();
        }
    }
}
