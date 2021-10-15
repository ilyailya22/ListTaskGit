﻿using System;
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

        public void Delete(int id, int task)
        {
            if (task == (int)Constants.MainTask)
            {
                _dataBaseService.DeleteTask(id);
            }

            if (task == (int)Constants.SubTask)
            {
                _dataBaseService.DeleteSubtask(id);
            }
        }

        public void DeleteAll()
        {
        }

        public void Edit(int id, BaseTask task)
        {
            if (task is MainTask mainTask)
            {
                _dataBaseService.EditTask(id, mainTask);
            }

            if (task is SubTask subTask)
            {
                _dataBaseService.EditSubtask(id, subTask);
            }
        }

        public void PrintByld(int id, int task)
        {
            if (task == (int)Constants.MainTask)
            {
                _dataBaseService.ReadTask(id);
            }

            if (task == (int)Constants.SubTask)
            {
                _dataBaseService.ReadSubtask(id);
            }
        }
    }
}