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

        public void Addmethod(MainTask taskRepository)
        {
            _repository.Add(taskRepository);
        }

        public void Deletemethod(Guid id)
        {
            _repository.Delete(id);
        }

        public void DeleteAllmethod()
        {
            _repository.DeleteAll();
        }

        public void Printmethod()
        {
            _repository.Print();
        }

        public void Menumethod()
        {
            _repository.Menu();
        }
    }
}