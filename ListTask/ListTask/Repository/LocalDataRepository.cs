using System;
using System.Collections.Generic;
using System.Linq;
using ListTask.Models;

namespace ListTask.Repository
{
    public class LocalDataRepository : IRepository
    {
        private List<MainTask> _taskRepository;

        public LocalDataRepository()
        {
            _taskRepository = new List<MainTask>();
        }

        public LocalDataRepository(int size)
        {
            _taskRepository = new List<MainTask>(size);
        }

        public void Add(BaseTask task)
        {
            if (task is MainTask mainTask)
            {
                _taskRepository.Add(mainTask);
            }

            if (task is SubTask subTask)
            {
                var parent = _taskRepository.FirstOrDefault(i => i.Id == subTask.Parent);
                if (parent != null)
                {
                    parent.Children.Add(subTask);
                }
            }
        }

        public void Delete(int id, TaskType taskType)
        {
            int tmp = 0;
            foreach (var i in _taskRepository)
            {
                if (i.Id == id)
                {
                    tmp = 1;
                    _taskRepository.Remove(i);
                    Console.WriteLine("Удаление успешно выполнено");
                    break;
                }
            }

            if (tmp != 1)
            {
                Console.WriteLine("Удаление не выполнена, такого имени нет");
            }
        }

        public void Print()
        {
            foreach (var i in _taskRepository)
            {
                i.ShowNameDate();
            }
        }

        public void PrintByld(int id, TaskType taskType)
        {
            int tmp = 0;
            foreach (var i in _taskRepository)
            {
                if (i.Id == id)
                {
                    tmp = 1;
                    i.ShowNameDate();
                    Console.WriteLine("Вывод успешно выполнен");
                    break;
                }
            }

            if (tmp != 1)
            {
                Console.WriteLine("Такого номера не має");
            }
        }

        public void DeleteAll()
        {
            _taskRepository.Clear();
        }

        public void Edit(BaseTask task)
        {
            int count = 0;
            foreach (MainTask s in _taskRepository)
            {
                if (s.Id == task.Id)
                    break;
                count++;
            }

            _taskRepository.RemoveAt(count);
            if (task is MainTask mainTask)
            {
                _taskRepository.Insert(count, mainTask);
            }

            if (task is SubTask subTask)
            {
                var parent = _taskRepository.FirstOrDefault(i => i.Id == subTask.Parent);
                if (parent != null)
                {
                    parent.Children.Add(subTask);
                    _taskRepository.Insert(count, parent);
                }
            }
        }
    }
}
