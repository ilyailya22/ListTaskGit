using System;
using System.Collections.Generic;
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
                _dataBaseService.EditTask(mainTask);
            }

            if (task is SubTask subTask)
            {
                _dataBaseService.EditSubtask(subTask);
            }
        }

        public IEnumerable<MainTask> ReadAll()
        {
            return _dataBaseService.ReadAll();
        }

        public void PrintByld(int id, TaskType taskType)
        {
            if (taskType == TaskType.MainTask)
            {
                MainTask maintask = _dataBaseService.ReadTask(id);
                maintask.ShowNameDate();
            }

            if (taskType == TaskType.SubTask)
            {
                SubTask subtask = _dataBaseService.ReadSubtask(id);
                subtask.ShowNameDate();
            }
        }

        public MainTask ReadByld(int id)
        {
            return _dataBaseService.ReadTask(id);
        }
    }
}
