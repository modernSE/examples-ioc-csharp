using System;

namespace Monolith
{
    class Program
    {
        static void Main(string[] args)
        {
            var monolith = new DocumentStorage();
            monolith.insertDocument("ImportLog", new Document("C:\\YellowMap\\ImportData\\StatusDaimler\\Import.log"));

            /******************
             * M  A  G  I  C  *
             ******************/

            Console.Write(monolith.getDocumentById("ImportLog").getJSONValue());

        }
    }
}
