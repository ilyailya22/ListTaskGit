using ListTask.Models;

namespace ListTask.Services
{
    public interface IDataBaseService
    {
        public void AddTask(MainTask maintaskobj);

        public void AddSubtask();

        public void ReadTask();

        public void ReadSubtask();

        public void EditTask();

        public void EditSubtask();

        public void DeleteTask();

        public void DeleteSubtask();
    }
}
