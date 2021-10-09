using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MemesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IMemeRepository _memeRepository;

        public ListController(IMemeRepository memeRepository)
        {
            _memeRepository = memeRepository;
        }
        
        // GET: api/List
        [HttpGet]
        public IEnumerable<MemeThumbnail> Get()
        {
            return _memeRepository.AllMemes;       // to returns a list of all memes
        }

        // // GET: api/List/5
        [HttpGet("{id}", Name = "Get")]
        public MemeThumbnail Get(int id)
        {
            return _memeRepository.GetMemeById(id);
        }
        
        
        
        // POST: api/List
        [HttpPost]
        public void Post([FromBody] JsonElement value)
        {
            //IEnumerable<string> test;
            
            var x = JsonSerializer.Serialize(value);
            var temporal = JsonSerializer.Deserialize<MemeThumbnail>(x);
            _memeRepository.AllMemes.Append(temporal);

        }
        //
        // // PUT: api/List/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE: api/List/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
