using System;
using ListTask.Models;
using Ninject;
using ListTask.Repository;
using ListTask.Controllers;
using System.Text.Json;
namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateadd1 = new DateTime(2002, 11, 06, 17, 30, 00);
            DateTime datedead1 = new DateTime(2003, 11, 06, 17, 30, 00);
            //LocalDataRepository repository = new LocalDataRepository();
            MainTask models1 = new MainTask("Ilya", "Merihov", dateadd1, datedead1);
            //repository.Addmethod(models1);
            //DateTime dateadd2 = new DateTime(2002, 9, 06, 00, 00, 00);
            //DateTime datedead2 = new DateTime(2003, 9, 06, 00, 00, 00);
            //MainTask models2 = new MainTask("", "", dateadd2, datedead2);
            //repository.Addmethod(models2);
            //repository.Print();
            //repository.DeleteAll();
            //DateTime dateadd3 = new DateTime(2000, 1, 01, 00, 00, 00);
            //DateTime datedead3 = new DateTime(2001, 2, 12, 00, 00, 00);
            //MainTask models3 = new MainTask("", "", dateadd3, datedead3);
            //repository.Addmethod(models3);
            //repository.Print();



            var bootstrapper = new Bootstrapper();
            var localDataRepository = new RepositoryController(Bootstrapper.Kernel.Get<IRepository>());
            localDataRepository.Add(models1);
            localDataRepository.PrintMethod();
            Console.ReadKey();
        }
    }
}
