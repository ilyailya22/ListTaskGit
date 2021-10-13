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
            var bootstrapper = new Bootstrapper();
            var localDataRepository = new RepositoryController(Bootstrapper.Kernel.Get<IRepository>());
            localDataRepository.Menu();
            Console.ReadKey();
        }
    }
}
