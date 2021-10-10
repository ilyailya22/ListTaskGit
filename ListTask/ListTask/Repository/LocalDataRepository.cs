using System;
using System.Collections.Generic;
using ListTask.Models;
using Newtonsoft.Json;

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

        public void Add(MainTask taskRepository)
        {
            _taskRepository.Add(taskRepository);
        }

        public void Delete(int number)
        {
            int tmp = 0;
            foreach (var i in _taskRepository)
            {
                if (i.Number == number)
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

        public void PrintByld(int number)
        {
            int tmp = 0;
            foreach (var i in _taskRepository)
            {
                if (i.Number == number)
                {
                    tmp = 1;
                    i.ShowNameDate();
                    Console.WriteLine("Вывод успешно выполнен");
                    break;
                }
            }

            if (tmp != 1)
            {
                Console.WriteLine("Такого номера не");
            }
        }

        public void DeleteAll()
        {
            _taskRepository.Clear();
        }

        public void Edit(int number, MainTask task)
        {
            int count = 0, index = -1;
            foreach (MainTask s in _taskRepository)
            {
                if (s.Number == number)
                    index = count; // I found a match and I want to edit the item at this index
                count++;
            }

            _taskRepository.RemoveAt(index);
            _taskRepository.Insert(index, task);
        }
    }
}
