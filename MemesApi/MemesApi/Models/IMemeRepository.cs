using System.Collections.Generic;

namespace MemesApi.Models
{
    public interface IMemeRepository
    {
        public IEnumerable<MemeThumbnail> AllMemes { get; }

        MemeThumbnail GetMemeById(int memeId);
    }
}