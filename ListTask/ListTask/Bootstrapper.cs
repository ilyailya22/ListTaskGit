using ListTask.Repository;
using ListTask.Services;
using Ninject;

namespace ListTask
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
            Kernel.Bind<IRequestService>().To<RequestService>();
            Kernel.Bind<IRepository>().To<LocalDataRepository>();
        }
    }
}
