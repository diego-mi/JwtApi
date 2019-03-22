using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using JwtAuthentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace JwtAuthenticationTest
{
    class TestClientProvider : IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; set; }

        public TestClientProvider()
        {
            var configs = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            server = new TestServer(new WebHostBuilder()
                .UseConfiguration(configs)
                .UseStartup<Startup>());

            Client = server.CreateClient();
        }

        public void Dispose()
        {
            server.Dispose();
            Client.Dispose();
        }
    }
}
