using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Exceptions;
using Raven.Client.Exceptions.Database;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;

namespace RavenSample.Web
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        public DocumentStoreHolder(IOptions<RavenDBSettings> ravenSettings)
        {
            var settings = ravenSettings.Value;

            Store = new DocumentStore
            {
                Urls = new [] {settings.Url},
                Database = settings.Database,
            }.Initialize();

            EnsureDatabaseExists();
        }

        private void EnsureDatabaseExists()
        {
            try
            {
                Store.Maintenance.ForDatabase(Store.Database).Send(new GetStatisticsOperation());
            }
            catch (DatabaseDoesNotExistException)
            {
                try
                {
                    Store.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord(Store.Database)));
                }
                catch (ConcurrencyException)
                {
                    // The database was already created before calling CreateDatabaseOperation
                }
            }
        }

        public IDocumentStore Store { get; }
    }
}