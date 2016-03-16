using System.Collections.Generic;
using System.IO;
using DIContainer.Interfaces;

namespace DIContainer
{
    class Document : IDocument
    {
        private string[] ContentStrings;
        private readonly Dictionary<int, string> ContentDictionary = new Dictionary<int, string>();

        public void readDocument(string pathWithFilename)
        {
            ContentStrings = File.ReadAllLines(pathWithFilename);
            int line = 0;
            foreach (var content in ContentStrings)
            {
                ContentDictionary.Add(line, content);
                line++;
            }
        }

        public string[] getContent()
        {
            return ContentStrings;
        }

        public Dictionary<int, string> getContentDictionary()
        {
            return ContentDictionary;
        }
    }
}
