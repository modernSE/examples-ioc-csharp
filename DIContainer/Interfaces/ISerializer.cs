namespace DIContainer.Interfaces
{
    interface ISerializer
    {
        string serialize(IDocument document, ReturnTypes type);
    }
}