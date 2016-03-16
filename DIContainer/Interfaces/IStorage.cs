namespace DIContainer.Interfaces
{
    internal interface IStorage
    {
        IDocument getDocumentById(string key);
        void insertDocument(string key, IDocument document);
    }
}