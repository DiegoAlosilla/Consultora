using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using ConsultoraAPI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace XIntegrationTestProyecto
{
    public class TestClientProvider : IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; set; }

        public TestClientProvider()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
