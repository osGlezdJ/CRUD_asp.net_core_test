using System.Collections.Generic;

namespace MemesApi.Models
{
    public interface IMemeRepository
    {
        public IList<MemeThumbnail> AllMemes { get; }
        
        MemeThumbnail GetMemeById(int memeId);
    }
}