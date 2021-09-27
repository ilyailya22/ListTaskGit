using Ninject;
using Models;
using System;

namespace Repository
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
    }
}

