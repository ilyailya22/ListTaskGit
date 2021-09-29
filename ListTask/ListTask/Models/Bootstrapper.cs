using Ninject;
using ListTask.Repository;
namespace ListTask.Models
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            Kernel = new StandardKernel();

            InitializeDependencies();
        }

        public static IKernel Kernel { get; private set; }

        private void InitializeDependencies()
        {
            Kernel.Bind<IRepository>().To<WebAppRepository>();
        }
    }
}
