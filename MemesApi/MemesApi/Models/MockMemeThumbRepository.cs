using System.Collections.Generic;
using System.Linq;

namespace MemesApi.Models
{
    //here to generate the data of the memes
    public class MockMemeThumbRepository : IMemeRepository
    {

        public IList<MemeThumbnail> AllMemes => new List<MemeThumbnail>
                {
                    new MemeThumbnail { MemeId = 1, Name = "Soccer meme", Description = "About the last journey in UCL", Width = 400, Height = 600, Original = "URI_1", Thumb = "ThumbUri_1"},
                    new MemeThumbnail { MemeId = 2, Name = "Baseball meme", Description = "About the last journey in MLB", Width = 400, Height = 600, Original = "URI_2", Thumb = "ThumbUri_2" },
                    new MemeThumbnail { MemeId = 3, Name = "Cinema meme", Description = "About the last Oscar's Awards", Width = 400, Height = 600, Original = "URI_3", Thumb = "ThumbUri_3" },
                    new MemeThumbnail { MemeId = 4, Name = "Grammy's meme", Description = "About the last Grammy's Awards", Width = 400, Height = 600, Original = "URI_4", Thumb = "ThumbUri_4" },
                    new MemeThumbnail { MemeId = 5, Name = "Math meme", Description = "About the linear function", Width = 400, Height = 600, Original = "URI_5", Thumb = "ThumbUri_5" },
                    new MemeThumbnail { MemeId = 6, Name = "Language meme", Description = "About the Irish pronunciation", Width = 400, Height = 600, Original = "URI_6", Thumb = "ThumbUri_6" },
                    new MemeThumbnail { MemeId = 7, Name = "Coffee meme", Description = "About the caffeine", Width = 400, Height = 600, Original = "URI_7", Thumb = "ThumbUri_7" }

                };
     
        

        public MemeThumbnail GetMemeById(int memeId)
        {
            return AllMemes.FirstOrDefault(m => m.MemeId == memeId);
        }
    }
}