using System.Collections.Generic;

namespace DIContainer.Interfaces
{
    internal interface IDocument
    {
        string[] getContent();
        void readDocument(string pathWithFilename);
        Dictionary<int, string> getContentDictionary();
    }
}