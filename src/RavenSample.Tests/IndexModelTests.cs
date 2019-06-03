using Raven.TestDriver;
using RavenSample.Web;
using RavenSample.Web.Pages;
using Xunit;

namespace RavenSample.Tests
{
    public class IndexModelTests : RavenTestDriver
    {
        [Fact]
        public void LoadPerson()
        {
            using (var store = GetDocumentStore())
            {
                using (var session = store.OpenSession())
                {
                    session.Store(new Person { Id = "12345", Name = "Michael" });
                    session.SaveChanges();
                }

                using (var session = store.OpenSession())
                {
                    var sut = new IndexModel(session);

                    sut.OnGet();

                    Assert.NotNull(sut.Person);
                }
            }
        }
    }
}
