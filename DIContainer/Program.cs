using System;
using DIContainer.Interfaces;

namespace DIContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceRepo = new ServiceRepo();
            var storage = serviceRepo.DIContainer.GetInstance<IStorage>();
            var document = serviceRepo.DIContainer.GetInstance<IDocument>();
            document.readDocument("C:\\YellowMap\\ImportData\\StatusDaimler\\Import.log");
            storage.insertDocument("ImportLog",document);

            /******************
             * M  A  G  I  C  *
             ******************/
            var serializer = serviceRepo.DIContainer.GetInstance<ISerializer>();

            Console.Write(serializer.serialize(storage.getDocumentById("ImportLog"), ReturnTypes.XML));
        }
    }
}
