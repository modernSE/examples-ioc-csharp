using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Monolith
{
    class DocumentStorage
    {
        private readonly Dictionary<string,Document> StorageDictionary = new Dictionary<string, Document>() ;

        public void insertDocument(string key, Document document)
        {
            StorageDictionary.Add(key,document);
        }

        public Document getDocumentById(string key)
        {
            Document returnDocument;
            StorageDictionary.TryGetValue(key, out returnDocument);
            return returnDocument;
        }
    }

    internal class Document
    {
        private readonly Dictionary<int,string> ContentDictionary = new Dictionary<int, string>();

        public Document(string pathWithFilename)
        {
            string[] contentsStrings = File.ReadAllLines(pathWithFilename);
            int line = 0;
            foreach (var content in contentsStrings)
            {
                ContentDictionary.Add(line,content);
                line++;
            }
        }

        public string getJSONValue()
        {
            return JsonConvert.SerializeObject(ContentDictionary);
        }

        public string getXMLValue()
        {
            var el = new XElement("root", ContentDictionary.Select(content => new XElement(content.Key.ToString(CultureInfo.InvariantCulture), content.Value)));
            return el.ToString();
        }

   }
}
