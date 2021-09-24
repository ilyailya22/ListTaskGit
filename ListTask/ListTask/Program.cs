using System;
using System.Collections.Generic;
using Models;
using Repository;
namespace Models
{
    class MainTasks
    {
        public Guid Id = Guid.NewGuid();
        public string Name;
        public string About;
        public DateTime DateAdd;
        public DateTime DateDead;
        public MainTasks(string n, string a,DateTime da, DateTime dd)
        {
            Name = n;
            About = a; DateAdd = da; DateDead = dd;
        }
        public void Show()
        {
            Console.WriteLine("Id " + Id + " Name " + Name + " About " + About + "\nDateAdd " + DateAdd + " DateDead " + DateDead);
        }

    }
}
namespace Repository
{
    class Repositories
    {
        public List<MainTasks> TaskRepository;
        public Repositories() { TaskRepository = new List<MainTasks>(); }
        public Repositories(int n) { TaskRepository = new List<MainTasks>(n); }
        public void Addmethod(MainTasks a)
        {
            TaskRepository.Add(a);
        }
        public void Deletemethod(Guid a)
        {
            int tmp = 0;
            foreach (var i in TaskRepository)
            {
                if (i.Id == a)
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

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateadd1 = new DateTime(2002, 11, 06, 17, 30, 00);
            DateTime datedead1 = new DateTime(2003, 11, 06, 17, 30, 00);
            Repositories repository = new Repositories();
            MainTasks models1 = new MainTasks("", "", dateadd1, datedead1);
            repository.Addmethod(models1);
            DateTime dateadd2 = new DateTime(2002, 9, 06, 00, 00, 00);
            DateTime datedead2 = new DateTime(2003, 9, 06, 00, 00, 00);
            MainTasks models2 = new MainTasks("", "", dateadd2, datedead2);
            repository.Addmethod(models2);
            repository.Print();
            repository.DeleteAll();
            DateTime dateadd3 = new DateTime(2000, 1, 01, 00, 00, 00);
            DateTime datedead3 = new DateTime(2001, 2, 12, 00, 00, 00);
            MainTasks models3 = new MainTasks("", "", dateadd3, datedead3);
            repository.Addmethod(models3);
            repository.Print();
            Console.ReadKey();
        }
    }
}
