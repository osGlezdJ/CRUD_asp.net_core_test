using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using MemesApi.Data;
using MemesApi.Models;

namespace TestForMemesApi
{
    public class CreateResources : IDisposable
    {
        public MockMemeThumbRepository Meme { get; private set; }
        public List<MemeThumbnail> Th { get; }
        public MemeThumbnail Temp1 { get; set; }
        
        public MemeThumbnail Temp2 { get; set; }


        public CreateResources()
        {
            Meme = new MockMemeThumbRepository();
            
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
            
            Temp1 = new MemeThumbnail()
            {
                MemeId = 1, Name = "Soccer meme", Description = "About the last journey in UCL", Width = 400,
                Height = 600, Original = "URI_1", Thumb = "ThumbUri_1"
            };
            
            Temp2 = new MemeThumbnail()
            {
                MemeId = 500, Name = "Weird meme"
            };

        }
        

        public void Dispose()
        {
            GC.SuppressFinalize(Meme);
            GC.SuppressFinalize(Th);
            GC.SuppressFinalize(Temp1);
            
        }
    }
}