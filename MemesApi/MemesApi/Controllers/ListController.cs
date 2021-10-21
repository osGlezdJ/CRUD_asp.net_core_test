using System;
using System.Collections.Generic;
using System.Text.Json;
using MemesApi.Data;
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
            if (value.ValueKind == JsonValueKind.Object)
            {
                var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
                var x = JsonSerializer.Serialize(value, options);
                var temporal = JsonSerializer.Deserialize<MemeThumbnail>(x,options);
                var temp_ls = new List<MemeThumbnail>() { temporal};
                _memeRepository.AddItem(temp_ls);
                return Created(String.Empty, temporal);
            }
            else
            {
                var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
                var x = JsonSerializer.Serialize(value, options);
                var temporal = JsonSerializer.Deserialize<List<MemeThumbnail>>(x, options); //I get MemeThumbnail from received json
                _memeRepository.AddItem(temporal);
                return Created(String.Empty, temporal);
            }
            
            

        }
        
        
        
        // PUT: api/List/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] JsonElement value)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
            var x = JsonSerializer.Serialize(value, options);
            var temporal = JsonSerializer.Deserialize<MemeThumbnail>(x,options);
            _memeRepository.MyList[id] = temporal;
            return $"item {temporal!.Name} updated successfully";
        }
        
        
        
        // DELETE: api/List/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (_memeRepository.MyList.Count == 0)
            {
                return "There is not memes for remove";
            }
            _memeRepository.MyList.RemoveAt(id);
            return "item removed successfully";
        }
    }
}
