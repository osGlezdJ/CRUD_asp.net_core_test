using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace TestForMemesApi
{
    public class MyMemeControllerTests : BaseTestWithMongoDb
    {
        public MyMemeControllerTests(MongoDbFixture mongoFixture) : base(mongoFixture)
        {
        }

        [Fact]
        public async Task MyTest()
        {
            using var host = GivenHost();
            await host.StartAsync();
            var client = host.GetTestClient();
            //var client = host.CreateClient();
            var response = await client.GetAsync(@"api/MyMemes/");
            Assert.True(response.IsSuccessStatusCode);
        }
        
        [Fact]
        public async Task MyTest2()
        {
            using var host = GivenHost();
            await host.StartAsync();
            var client = host.GetTestClient();

           //var content = new StringContent("memeIncoming.json");
           
           var addString = "[\n    {\n   " +
                            " " +
                            "    \"memeId\": 100,\n    " +
                            "    \"name\": \"Meme Test\",\n    " +
                            "    \"description\": \"Only for a test\",\n    " +
                            "    \"width\": 400,\n        \"height\": 600,\n    " +
                            "    \"original\": \"URI_100\",\n    " +
                            "    \"thumb\": \"ThumbUri_100\"\n    },\n    {\n    " +
                            "    \"memeId\": 101,\n        \"name\": \"Other Meme test\",\n    " +
                            "    \"description\": \"Only for a test\",\n     " +
                            "   \"width\": 400,\n        \"height\": 600,\n    " +
                            "    \"original\": \"URI_101\",\n    " +
                            "    \"thumb\": \"ThumbUri_101\"\n    }\n]";

           var addJson = JsonSerializer.Deserialize<JsonElement>(addString);
           var content = JsonContent.Create(addJson);
           

            await client.PostAsync(@"api/MyMemes/", content);
            var dataPersist = await client.GetAsync(@"api/MyMemes/");
            
            
            
            //Assert.Equal(addjson, dataPersist.Content);
        }
    }
}