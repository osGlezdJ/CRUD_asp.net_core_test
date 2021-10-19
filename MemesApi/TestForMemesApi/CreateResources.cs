using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using MemesApi.Models;

namespace TestForMemesApi
{
    public class CreateResources : IDisposable
    {
        public MockMemeThumbRepository Meme { get; private set; }

        //public JsonElement Json { get; private set; }

        public List<MemeThumbnail> Th { get; }


        public CreateResources()
        {
            Meme = new MockMemeThumbRepository();
            // var temp = JsonSerializer.Serialize(th);
            // Json = JsonSerializer.Deserialize<JsonElement>(temp);
            Th = new()
            {
                new MemeThumbnail()
                {
                    MemeId = 101,
                    Name = "Test meme",
                    Description = "This is a meme for a test",
                    Width = 400,
                    Height = 600,
                    Original = "URI_test",
                    Thumb = "ThumbUri_test"
                }
            };

        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(Meme);
        }
    }
}