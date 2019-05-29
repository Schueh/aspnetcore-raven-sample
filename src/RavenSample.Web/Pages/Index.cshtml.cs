using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Raven.Client.Documents.Session;

namespace RavenSample.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDocumentSession _documentSession;

        public IndexModel(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public Person Person { get; private set; }

        public void OnGet()
        {
            Person = _documentSession.Query<Person>().FirstOrDefault();
        }
    }
}
