using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using MemesApi;
using MemesApi.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace TestForMemesApi
{
    public class BaseTestWithMongoDb : IClassFixture<MongoDbFixture>
    {
        private readonly MongoDbFixture _mongoFixture;
        private Mock<MemesDatabaseSettings> mockDbSettings = new();

        public BaseTestWithMongoDb(MongoDbFixture mongoFixture)
        {
            _mongoFixture = mongoFixture;
        }


        protected IWebHost GivenHost()
        {
            var memesDatabaseSettings = new MemesDatabaseSettings()
            {
                ConnectionString = _mongoFixture.Container.ConnectionString,
                DatabaseName = _mongoFixture.Container.Database,
                MemesCollectionName = "Memes"
            };
            
            
            //mockDbSettings.Setup(n => n.DatabaseName).Equals(_mongoFixture.Container.Database);
            //var projectDir = typeof(Startup).GetTypeInfo().Assembly.Location;
            var builder = new WebHostBuilder()
                .UseTestServer()
                .UseEnvironment("Tests")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(new ConfigurationBuilder()
                    //.SetBasePath(projectDir)
                    //.AddJsonFile("appsettings.json")
                    .Build()
                )
                .ConfigureTestServices(services =>
                {
                    services.AddSingleton<IMongoClient>(sp => _mongoFixture.MongoClient);
                    services.AddSingleton<IMemesDatabaseSettings>(sp => memesDatabaseSettings);

                })
                .UseStartup<MemesApi.Startup>();

            var tserver = new TestServer(builder);
            var host = tserver.Host;
            //var host = builder.Build();
            
            //host.Start();
            return host;
        }
    }
}