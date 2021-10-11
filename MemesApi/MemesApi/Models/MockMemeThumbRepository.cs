using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MemesApi.Models
{
    //here to generate the data of the memes
    public class MockMemeThumbRepository : IMemeRepository
    {
        public List<MemeThumbnail> MyList { get; set; } = new();
        
        public List<MemeThumbnail> AllMemes =>
            new List<MemeThumbnail>
            {
                new MemeThumbnail
                {
                    MemeId = 1, Name = "Soccer meme", Description = "About the last journey in UCL", Width = 400,
                    Height = 600, Original = "URI_1", Thumb = "ThumbUri_1"
                },
                new MemeThumbnail
                {
                    MemeId = 2, Name = "Baseball meme", Description = "About the last journey in MLB", Width = 400,
                    Height = 600, Original = "URI_2", Thumb = "ThumbUri_2"
                },
                new MemeThumbnail
                {
                    MemeId = 3, Name = "Cinema meme", Description = "About the last Oscar's Awards", Width = 400,
                    Height = 600, Original = "URI_3", Thumb = "ThumbUri_3"
                }
            };

        //init the repository
        public MockMemeThumbRepository()
        {
            MyList.AddRange(AllMemes);
        }
        
        //read meme by Id via http Get method
        public MemeThumbnail GetMemeById(int memeId)
        {
            //var temp = MyList[memeId];
            //return MyList.FirstOrDefault(m => m.MemeId == memeId);
            return MyList[memeId];
        }

        //create CRUD function via http POST
        public void AddItem (List<MemeThumbnail> item)
        {
            MyList.AddRange(item);
        }
    }
}