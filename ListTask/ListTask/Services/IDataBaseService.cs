using ListTask.Models;

namespace ListTask.Services
{
    public interface IDataBaseService
    {
        public void AddTask(MainTask mainTask);

        public void AddSubtask(SubTask subTask);

        public MainTask ReadTask(int id);

        public SubTask ReadSubtask(int id);

        public void EditTask(MainTask mainTask);

        public void EditSubtask(SubTask subTask);

        public void DeleteTask(int id);

        public void DeleteSubtask(int id);
    }
}
