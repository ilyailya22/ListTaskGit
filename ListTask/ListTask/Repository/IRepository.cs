using System;
using ListTask.Models;

namespace ListTask.Repository
{
    public interface IRepository
    {
        void Add(MainTask taskRepository);

        void Delete(Guid taskRepository);

        void DeleteAll();

        void Print();
    }
}
