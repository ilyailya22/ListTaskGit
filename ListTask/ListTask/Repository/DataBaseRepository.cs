using System;
using ListTask.Models;
using ListTask.Services;

namespace ListTask.Repository
{
    public class DataBaseRepository : IRepository
    {
        private IDataBaseService _dataBaseService;

        public DataBaseRepository(IDataBaseService service)
        {
            _dataBaseService = service;
        }

        public void Add(BaseTask task)
        {
            if (task is MainTask mainTask)
            {
                _dataBaseService.AddTask(mainTask);
            }

            if (task is SubTask subTask)
            {
                _dataBaseService.AddSubtask(subTask);
            }
        }

        public void Delete(int id, TaskType taskType)
        {
            if (taskType == TaskType.MainTask)
            {
                _dataBaseService.DeleteTask(id);
            }

            if (taskType == TaskType.SubTask)
            {
                _dataBaseService.DeleteSubtask(id);
            }
        }

        public void DeleteAll()
        {
        }

        public void Edit(BaseTask task)
        {
            if (task is MainTask mainTask)
            {
                _dataBaseService.EditTask(mainTask.Id, mainTask);
            }

            if (task is SubTask subTask)
            {
                _dataBaseService.EditSubtask(subTask.Id, subTask);
            }
        }

        public void PrintByld(int id, TaskType taskType)
        {
            if (taskType == TaskType.MainTask)
            {
                _dataBaseService.ReadTask(id);
            }

            if (taskType == TaskType.SubTask)
            {
                _dataBaseService.ReadSubtask(id);
            }
        }
    }
}
