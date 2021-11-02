using System.Collections.Generic;
using System.Threading.Tasks;
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
        public BaseTask ReadByld(int id)
        {
            return _repository.ReadByld(id);
        }
    }
}
