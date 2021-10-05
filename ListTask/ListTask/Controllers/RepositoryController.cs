using System;
using ListTask.Models;
using ListTask.Repository;

namespace ListTask.Controllers
{
    public class RepositoryController
    {
        private readonly IRepository _repository;

        public RepositoryController(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(MainTask taskRepository)
        {
            _repository.Addmethod(taskRepository);
        }

        public void Delete(Guid id)
        {
            _repository.Deletemethod(id);
        }

        public void DeleteAl()
        {
            _repository.DeleteAll();
        }

        public void PrintMethod()
        {
            _repository.Print();
        }
    }
}