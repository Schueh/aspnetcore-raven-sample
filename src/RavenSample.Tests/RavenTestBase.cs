using System;
using Raven.TestDriver;

namespace RavenSample.Tests
{
    // TODO: use xunit fixtures instead of base class?
    public abstract class RavenTestBase : RavenTestDriver
    {
        protected void ConfigureServer()
        {
            ConfigureServer(new TestServerOptions
            {
                FrameworkVersion = "2.2.5" // FIXME: get it running without setting a specific version
            });
        }
    }
}