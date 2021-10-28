using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using MemesApi.Controllers;
using MemesApi.Data;
using Moq;
using Xunit;

namespace TestForMemesApi
{
    public class MyMemeControllerTests
    {
        ITestcontainersBuilder<MongoDbTestcontainer> conte = new TestcontainersBuilder<MongoDbTestcontainer>().WithPortBinding("8008")
            .WithDatabase(new MongoDbTestcontainerConfiguration
            {
                Database = "db",
                Username = "admin",
                Password = "admin"
            });



        // ITestcontainersBuilder<TestcontainersContainer> testcontainersBuilder = new TestcontainersBuilder<TestcontainersContainer>()
        //     .WithImage("mongo")
        //     .WithName("mongo")
        //     .WithPortBinding(8007)
        //     .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(8007));
        
        


        [Fact]
        public async Task MyTest()
        {
            var testcontainer = conte.Build();
            await testcontainer.StartAsync();
            var tempClient = testcontainer.ConnectionString;
            var tempDb = testcontainer.Name;

            // var collectionMock = new Mock<MemeCollection>();
            // var myController = new MyMemesController(collectionMock.Object);
            //await testcontainer.DisposeAsync();
        }

    }
}