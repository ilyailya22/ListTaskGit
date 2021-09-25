using System;
using System.Linq;
using System.Collections.Generic;
using Models;
using Repository;
namespace Models
{
    class MainTask
    {
        public Guid Id = Guid.NewGuid();
        public string Name { get; set; }
        public string About { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateDead { get; set; }

        public MainTask(string name, string about,DateTime dateadd, DateTime datedead)
        {
            Name = name;
            About = about; 
            DateAdd = dateadd; 
            DateDead = datedead;
        }

        public void Show()
        {
            Console.WriteLine("Id " + Id + " Name " + Name + " About " + About + "\nDateAdd " + DateAdd + " DateDead " + DateDead);
        }

    }
}
namespace Repository
{
    class LocalDataRepository
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
    class LocalKeyValueRepository
    {
        public Dictionary<Guid,MainTask> KeyTaskRepository;

        public LocalKeyValueRepository() { KeyTaskRepository = new Dictionary<Guid, MainTask>(); }

        public LocalKeyValueRepository(int size) { KeyTaskRepository = new Dictionary<Guid, MainTask>(size); }

        public void Addmethod(Guid id,MainTask taskRepository)
        {
            KeyTaskRepository.Add(id,taskRepository);
        }

        public void Deletemethod(Guid id)
        {
            KeyTaskRepository.Remove(id);
        }

        public void Print(Dictionary<Guid, MainTask> taskRepository)
        {
            for(int i=0;i<taskRepository.Count;i++)
            {
                KeyValuePair<Guid, MainTask> entry = taskRepository.ElementAt(i);
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }

        public void DeleteAll()
        {
            KeyTaskRepository.Clear();
        }

    }
}

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateadd1 = new DateTime(2002, 11, 06, 17, 30, 00);
            DateTime datedead1 = new DateTime(2003, 11, 06, 17, 30, 00);
            LocalDataRepository repository = new LocalDataRepository();
            MainTask models1 = new MainTask("", "", dateadd1, datedead1);
            repository.Addmethod(models1);
            DateTime dateadd2 = new DateTime(2002, 9, 06, 00, 00, 00);
            DateTime datedead2 = new DateTime(2003, 9, 06, 00, 00, 00);
            MainTask models2 = new MainTask("", "", dateadd2, datedead2);
            repository.Addmethod(models2);
            repository.Print();
            repository.DeleteAll();
            DateTime dateadd3 = new DateTime(2000, 1, 01, 00, 00, 00);
            DateTime datedead3 = new DateTime(2001, 2, 12, 00, 00, 00);
            MainTask models3 = new MainTask("", "", dateadd3, datedead3);
            repository.Addmethod(models3);
            repository.Print();
            Console.ReadKey();
        }
    }
}
