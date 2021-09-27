using System;
using System.Linq;
using System.Collections.Generic;
using Models;
namespace Repository
{
    public interface IRepository
    {
        void Addmethod(MainTask taskRepository);

        void Deletemethod(Guid taskRepository);

        void DeleteAll();

        void Print();
    }
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
    public class LocalKeyValueRepository : IRepository
    {
        public Dictionary<Guid, MainTask> KeyTaskRepository;

        public LocalKeyValueRepository() { KeyTaskRepository = new Dictionary<Guid, MainTask>(); }

        public LocalKeyValueRepository(int size) { KeyTaskRepository = new Dictionary<Guid, MainTask>(size); }

        public void Addmethod(MainTask taskRepository)
        {
            Guid id = Guid.NewGuid();
            KeyTaskRepository.Add(id, taskRepository);
        }

        public void Deletemethod(Guid id)
        {
            KeyTaskRepository.Remove(id);
        }

        public void Print()
        {
            for (int i = 0; i < KeyTaskRepository.Count; i++)
            {
                KeyValuePair<Guid, MainTask> entry = KeyTaskRepository.ElementAt(i);
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }

        public void DeleteAll()
        {
            KeyTaskRepository.Clear();
        }

    }
}
