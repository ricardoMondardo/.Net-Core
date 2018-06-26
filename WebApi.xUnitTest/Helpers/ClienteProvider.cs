using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace WebApi.IntegrationTest
{
    public class ClienteProvider : IDisposable
    {
        private TestServer _server;

        public HttpClient Client { get; set; }

        public ClienteProvider()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }

        public void Dispose()
        {
            _server?.Dispose();
            Client?.Dispose();
        }
    }
}
