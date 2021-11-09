using System;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using MongoDB.Driver;
using Xunit;

namespace TestForMemesApi
{
    public class MongoDbFixture : IAsyncLifetime, IDisposable
    {
        internal MongoDbTestcontainer Container { get; set; }
        public IMongoClient MongoClient { get; set; }
        
        public MongoDbFixture()
        {
            Container = new TestcontainersBuilder<MongoDbTestcontainer>()
                .WithDatabase(new MongoDbTestcontainerConfiguration
                {
                    Database = "db",
                    Username = "mongoadmin",
                    Password = "secret",
                    Port = 8008
                })
                .Build();
        }
        
        public async Task InitializeAsync()
        { 
            await Container.StartAsync().ConfigureAwait(false);
            //var settings = MongoClientSettings.FromConnectionString(Container.ConnectionString);
           MongoClient = new MongoClient(Container.ConnectionString);
           //MongoClient.GetDatabase(Container.Database);
            //await MongoClient.StartSessionAsync();
        }

        public async Task DisposeAsync()
        {
            await Container.DisposeAsync();
        }

        public void Dispose()
        {
            // no longer used
        }
    }
    
}