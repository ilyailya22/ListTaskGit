using System;
using System.Collections.Generic;
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

        public void Add(MainTask taskRepository)
        {
            _taskRepository.Add(taskRepository);
        }

        public void Delete(Guid taskRepository)
        {
            int tmp = 0;
            foreach (var i in _taskRepository)
            {
                if (i.Id == taskRepository)
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

        public void DeleteAll()
        {
            _taskRepository.Clear();
        }
    }
}
