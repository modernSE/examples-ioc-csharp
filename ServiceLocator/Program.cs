using Autofac;
using Microsoft.Practices.Unity;
using ServiceLocator.AutofacDocument;

namespace ServiceLocator
{
    internal class Program
    {
        public static IContainer Container;
        private static void Main(string[] args)
        {
            switch (args[0])
            {
                case "1":
                    // regular container usage => Autofac
                    // Types need to be registered, differs around frameworks
                    // Autofac requires to register concrete types for resolving, so does Castle
                    // Ninject, Unity does not require this
                    var builder = new ContainerBuilder();
                    builder.RegisterType<DocumentStorage>();
                    builder.RegisterType<Document>().As<IDocument>();
                    builder.RegisterType<Serializer>().As<ISerializer>();

                    Container = builder.Build();
                    var Storage = Container.Resolve<DocumentStorage>();
                    break;
                case "2":
                    var unityContainer = new UnityContainer();
                    unityContainer.RegisterType<IDocument, Document>();
                    unityContainer.RegisterType<ISerializer, Serializer>();

                    var UnityStorage = unityContainer.Resolve<DocumentStorage>();
                    break;
            }
        }
    }
}