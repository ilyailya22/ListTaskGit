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
                i.Show();
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
                    i.Show();
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
    }
}
