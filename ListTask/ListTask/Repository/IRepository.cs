using System;
using ListTask.Models;

namespace ListTask.Repository
{
    public interface IRepository
    {
        void Add(MainTask taskRepository);

        void Delete(int number);

        void DeleteAll();

        void Print();

        void PrintByld(int number);
    }
}
