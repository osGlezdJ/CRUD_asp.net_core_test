using System.Collections.Generic;

namespace MemesApi.Models
{
    public interface IMemeRepository
    {
        public List<MemeThumbnail> AllMemes { get;}
        public List<MemeThumbnail> MyList { get; set; }
        MemeThumbnail GetMemeById(int memeId);
        void AddItem(MemeThumbnail item);
    }
}