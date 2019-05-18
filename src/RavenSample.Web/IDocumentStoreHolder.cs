using Raven.Client.Documents;

namespace RavenSample.Web
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore Store { get; }
    }
}