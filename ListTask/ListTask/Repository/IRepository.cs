using ListTask.Models;

namespace ListTask.Repository
{
    public interface IRepository
    {
        void Add(BaseTask task);

        void Delete(int id, int task);

        void DeleteAll();

        void PrintByld(int id, int task);

        void Edit(int id, BaseTask task);
    }
}
