using System;
using System.Collections.Generic;
using System.Text.Json;
using MemesApi.Models;
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
        public IList<MemeThumbnail> Get()
        {
            return _memeRepository.MyList;       // to returns a list of all memes
        }

        // // GET: api/List/5
        [HttpGet("{id}", Name = "Get")]
        public MemeThumbnail Get(int id)
        {
            return _memeRepository.GetMemeById(id);
        }
        
        
        // POST: api/List
        [HttpPost]
        public IActionResult Post([FromBody] JsonElement value)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
            var x = JsonSerializer.Serialize(value, options);
            var temporal = JsonSerializer.Deserialize<List<MemeThumbnail>>(x,options);    //I get MemeThumbnail from received json
            _memeRepository.AddItem(temporal);
            return Created(String.Empty, temporal);

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
