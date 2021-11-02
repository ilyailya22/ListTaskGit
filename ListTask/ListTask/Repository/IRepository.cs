using System.Collections.Generic;
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

        IEnumerable<MainTask> ReadAllMainTask();

        IEnumerable<SubTask> ReadAllSubTask();

        MainTask ReadByldMainTask(int id);

        SubTask ReadByldSubTask(int id);
    }
}
