using ListTask.Models;

namespace ListTask.Repository
{
    public interface IRepository
    {
        void Add(BaseTask task);

        void Delete(int id, TaskType taskType);

        void DeleteAll();

        void PrintByld(int id, TaskType taskType);

        void Edit(BaseTask task);
    }
}
