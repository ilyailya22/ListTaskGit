using System;
using ListTask.Models;

namespace ListTask.Repository
{
    public interface IRepository
    {
        void Addmethod(MainTask taskRepository);

        void Deletemethod(Guid taskRepository);

        void DeleteAll();

        void Print();
    }
}
