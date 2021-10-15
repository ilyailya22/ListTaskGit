using ListTask.Models;

namespace ListTask.Repository
{
    public interface IRepository
    {
        void Add(BaseTask task);

        void Delete(int id, string task);

        void DeleteAll();

        void Print();

        void PrintByld(int id, string task);

        void Edit(int id, BaseTask task);
    }
}
