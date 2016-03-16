using DIContainer.Interfaces;
using SimpleInjector;

namespace DIContainer
{
    class ServiceRepo
    {
        public readonly Container DIContainer = new Container();
        public ServiceRepo()
        {
            DIContainer.Register<IStorage,DocumentStorage>(Lifestyle.Transient);
            DIContainer.Register<IDocument,Document>(Lifestyle.Transient);
            DIContainer.Verify();
        }
    }
}

