using ListTask.Models;

namespace ListTask.Repository
{
    public interface IRepository
    {
        void Add(MainTask taskRepository);

        void Delete(int id);

        void DeleteAll();

        void Print();

        void PrintByld(int id);

        void Edit(int id, MainTask task);
    }
}
