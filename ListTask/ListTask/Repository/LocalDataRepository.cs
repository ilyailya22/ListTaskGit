using System;
using System.Collections.Generic;
using ListTask.Models;

namespace ListTask.Repository
{
    public class LocalDataRepository : IRepository
    {
        public List<MainTask> TaskRepository;

        public LocalDataRepository() { TaskRepository = new List<MainTask>(); }

        public LocalDataRepository(int size) { TaskRepository = new List<MainTask>(size); }

        public void Addmethod(MainTask taskRepository)
        {
            TaskRepository.Add(taskRepository);
        }

        public void Deletemethod(Guid taskRepository)
        {
            int tmp = 0;
            foreach (var i in TaskRepository)
            {
                if (i.Id == taskRepository)
                {
                    tmp = 1;
                    TaskRepository.Remove(i);
                    Console.WriteLine("Удаление успешно выполнено");
                    break;
                }
            }
            if (tmp != 1) Console.WriteLine("Удаление не выполнена, такого имени нет");

        }

        public void Print()
        {
            foreach (var i in TaskRepository)
            {
                i.Show();
            }
        }

        public void DeleteAll()
        {
            TaskRepository.Clear();
        }

    }
}
