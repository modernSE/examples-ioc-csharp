using System.Collections.Generic;
using DIContainer.Interfaces;

namespace DIContainer
{
    class DocumentStorage : IStorage
    {
        private readonly Dictionary<string, IDocument> StorageDictionary = new Dictionary<string, IDocument>();
        public void insertDocument(string key, IDocument document)
        {
            StorageDictionary.Add(key, document);
        }

        public IDocument getDocumentById(string key)
        {
            IDocument returnDocument;
            StorageDictionary.TryGetValue(key, out returnDocument);
            return returnDocument;
        }
    }
}
