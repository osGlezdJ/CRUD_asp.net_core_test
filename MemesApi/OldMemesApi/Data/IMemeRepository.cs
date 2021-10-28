using System.Collections.Generic;
using MemesApi.Models;

namespace MemesApi.Data
{
    public interface IMemeRepository
    {
        //public List<MemeThumbnail> AllMemes { get;}
        public List<MemeThumbnail> MyList { get; set; }
        MemeThumbnail GetMemeById(int memeId);
        void AddItem(List<MemeThumbnail> item);
    }
}