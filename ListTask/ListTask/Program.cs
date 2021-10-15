using System;
using ListTask;
using ListTask.Controllers;
using ListTask.Repository;
using Ninject;

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            var dataBaseRepository = new RepositoryController(Bootstrapper.Kernel.Get<IRepository>());
            dataBaseRepository.Menu();
            Console.ReadKey();
        }
    }
}
