using System.Collections.Generic;
using System.Text.Json;
using MemesApi.Controllers;
using MemesApi.Data;
using MemesApi.Models;
using Moq;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestForMemesApi
{
    public class ListControllerTests
    {
        // [Fact]
        // public void GetAllMemes()
        // {
        //     // //var repo_mock = new Mock<MockMemeThumbRepository>();
        //     // var list_mock = new Mock<ListController>();
        //     // list_mock.Setup(m => m.Get());
        //
        //     var memeMock = new Mock<IMemeRepository>();
        //
        //     var x = new ListController(memeMock.Object);
        //
        //     var memes = new List<MemeThumbnail>();
        //     memeMock.Setup(m => m.AddItem(It.Is<List<MemeThumbnail>>(memes => memes.Count == 3)));
        // }

        [Fact]
        public void GivenAnEmptyListOfMemes_WhenListControllerGet_ThenShouldReturnAnEmptyList()
        {
            var memeMock = new Mock<IMemeRepository>();
            var controller = new ListController(memeMock.Object);

            memeMock.Setup(m => m.MyList).Returns(new List<MemeThumbnail>());
            
            var memes = controller.Get();
            Assert.Empty(memes);
        }
        
        [Fact]
        public void GivenGetMethod_WhenRequestForAllMemesStored_ThenReturnsAllMemesStored()
        {
            var memeMock = new Mock<MockMemeThumbRepository>();
            var controller = new ListController(memeMock.Object);

            memeMock.SetupAllProperties();
            
            var result = controller.Get();
            
            Assert.Equal(result, memeMock.Object.MyList  );
            

        }

        [Fact]
        public void GivenPostMethod_WhenReceiveAnArrayOfMeme_ThenStoreThat()
        {
            var memeMock = new Mock<MockMemeThumbRepository>();
            var controller = new ListController(memeMock.Object);

            //string income = "{\n  \"MemeId\" : 101,\n  \"Name\" :\"Test meme\",\n  \"Description\" : \"This is a meme for a test\",\n  \"Width\" : 400,\n  \"Height\" : 600,\n  \"Original\" : \"URI_test\",\n  \"Thumb\" : \"ThumbUri_test\"\n}";

            string income = "[\n    {\n        \"memeId\": 100,\n        \"name\": \"Meme Test\",\n        \"description\": \"Only for a test\",\n        \"width\": 400,\n        \"height\": 600,\n        \"original\": \"URI_100\",\n        \"thumb\": \"ThumbUri_100\"\n    },\n    {\n        \"memeId\": 101,\n        \"name\": \"Other Meme test\",\n        \"description\": \"Only for a test\",\n        \"width\": 400,\n        \"height\": 600,\n        \"original\": \"URI_101\",\n        \"thumb\": \"ThumbUri_101\"\n    }\n]";
            
            //string income = "[\n    {\n        \"memeId\": 100,\n        \"Name\": \"Meme Test\",\n        \"Description\": \"Only for a test\",\n        \"Width\": 400,\n        \"Height\": 600,\n        \"Original\": \"URI_100\",\n        \"Thumb\": \"ThumbUri_100\"\n    }\n]";
            
            var jsonIncoming = JsonSerializer.Deserialize<JsonElement>(income);
            //var resultEx = JsonSerializer.Deserialize<List<MemeThumbnail>>(income);

            
            controller.Post(jsonIncoming);

            
            
            //Assert.NotStrictEqual<MemeThumbnail>(resultEx[0], memeMock.Object.MyList[3]);
            Assert.Contains(memeMock.Object.MyList, m => m.Name=="Meme Test");
            Assert.Contains(memeMock.Object.MyList, m => m.Name=="Other Meme test");

        }
        
        
        [Fact]
        public void GivenPostMethod_WhenReceiveOnlyOneMeme_ThenStoreThat()
        {
            var memeMock = new Mock<MockMemeThumbRepository>();
            var controller = new ListController(memeMock.Object);

            //string income = "{\n  \"MemeId\" : 101,\n  \"Name\" :\"Test meme\",\n  \"Description\" : \"This is a meme for a test\",\n  \"Width\" : 400,\n  \"Height\" : 600,\n  \"Original\" : \"URI_test\",\n  \"Thumb\" : \"ThumbUri_test\"\n}";

            string income = "[\n    {\n        \"memeId\": 100,\n        \"Name\": \"Meme Test\",\n        \"Description\": \"Only for a test\",\n        \"Width\": 400,\n        \"Height\": 600,\n        \"Original\": \"URI_100\",\n        \"Thumb\": \"ThumbUri_100\"\n    }\n]";
            
            var jsonIncoming = JsonSerializer.Deserialize<JsonElement>(income);
            //var resultEx = JsonSerializer.Deserialize<List<MemeThumbnail>>(income);

            
            controller.Post(jsonIncoming);

            
            
            //Assert.NotStrictEqual<MemeThumbnail>(resultEx[0], memeMock.Object.MyList[3]);
            Assert.Contains(memeMock.Object.MyList, m => m.Name=="Meme Test");

        }


        
        
        [Fact]
        public void GivenPutMethod_WhenPutMeme_ThenUpdateThat()
        {
            var memeMock = new Mock<MockMemeThumbRepository>();
            var controller = new ListController(memeMock.Object);

            string income = "{\n        \"memeId\": 110,\n        \"Name\": \"Meme Test Updated\",\n        \"Description\": \"Only for a PUT test\",\n        \"Width\": 400,\n        \"Height\": 600,\n        \"Original\": \"URI_110\",\n        \"Thumb\": \"ThumbUri_110\"\n    }";
            
            var jsonIncoming = JsonSerializer.Deserialize<JsonElement>(income);


            controller.Put(0, jsonIncoming);

            
            
            //Assert.NotStrictEqual<MemeThumbnail>(resultEx[0], memeMock.Object.MyList[3]);
            Assert.Equal( "Meme Test Updated",memeMock.Object.MyList[0].Name);

        }
    }
}