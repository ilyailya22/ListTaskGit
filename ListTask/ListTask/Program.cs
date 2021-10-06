using System;
using ListTask;
using ListTask.Controllers;
using ListTask.Models;
using ListTask.Repository;
using Ninject;

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime dateadd1 = new DateTime(2002, 11, 06, 17, 30, 00);
            DateTime datedead1 = new DateTime(2003, 11, 06, 17, 30, 00);
            MainTask models1 = new MainTask();
            var bootstrapper = new Bootstrapper();
            var localDataRepository = new RepositoryController(Bootstrapper.Kernel.Get<IRepository>());
            localDataRepository.Add(models1);
            localDataRepository.PrintMethod();
            Console.ReadKey();
        }
    }
}
