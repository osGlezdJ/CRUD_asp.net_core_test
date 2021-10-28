using System.Collections.Generic;
using System.Threading.Tasks;
using MemesApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MemesApi.Data
{
    public class MemeCollection : IMemeCollection
    {
        //private MongoDbRepository _repo = new();
        private IMongoCollection<Meme> Collection;


        public MemeCollection(IMemesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Collection = database.GetCollection<Meme>(settings.MemesCollectionName);
        }
        

        // public MemeCollection()
        // {
        //     Collection = _repo.db.GetCollection<Meme>("Memes");
        // }


        public async Task<List<Meme>> GetAllMemes()
        {
            //throw new System.NotImplementedException();
            var temporal = Collection.FindAsync(new BsonDocument());
            await temporal;
            return temporal.Result.ToList();
        }

        public async Task<List<Meme>> GetMemeById(string id)
        {
            //throw new System.NotImplementedException();
            var temporal = Collection.FindAsync(new BsonDocument{{"_id", new ObjectId(id)}});
            await temporal;
            return temporal.Result.ToList();

        }

        public async Task InsertMeme(Meme meme)
        {
            //throw new System.NotImplementedException();
            await Collection.InsertOneAsync(meme);

        }

        public async Task UpdateMeme(Meme meme)
        {
            //throw new System.NotImplementedException();
            var filter = Builders<Meme>.Filter.Eq(m => m.Id, meme.Id);
            await Collection.ReplaceOneAsync(filter, meme);
        }

        public async Task DeleteMeme(string id)
        {
            //throw new System.NotImplementedException();
            var filter = Builders<Meme>.Filter.Eq(m => m.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }
    }
}