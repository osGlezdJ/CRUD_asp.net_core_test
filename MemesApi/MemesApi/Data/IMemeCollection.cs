using System.Collections.Generic;
using System.Threading.Tasks;
using MemesApi.Models;

namespace MemesApi.Data
{
    public interface IMemeCollection
    {
        Task<List<Meme>> GetAllMemes();

        Task<List<Meme>> GetMemeById(string id);

        Task InsertMeme(Meme meme);

        Task UpdateMeme(Meme meme);

        Task DeleteMeme(string id);


    }
}