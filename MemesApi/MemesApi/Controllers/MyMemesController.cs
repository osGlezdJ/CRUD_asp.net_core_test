using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemesApi.Data;
using MemesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace MemesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyMemesController : ControllerBase
    {
        private readonly IMemeCollection _collection;

        public MyMemesController(IMemeCollection collection)
        {
            _collection = collection;
        }
        
        // GET: api/MyMemes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _collection.GetAllMemes());
        }

        // GET: api/MyMemes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _collection.GetMemeById(id));
        }

        // POST: api/MyMemes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Meme meme)
        {
            if (meme == null)
            {
                return BadRequest();
            }

            if (meme.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The meme's name it's required");
            }

            await _collection.InsertMeme(meme);
            return Created(String.Empty, meme);

        }

        // PUT: api/MyMemes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Meme meme)
        {
            if (meme == null)
            {
                return BadRequest();
            }

            if (meme.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The meme's name it's required");
            }

            meme.Id = new ObjectId(id);
            await _collection.UpdateMeme(meme);
            return Created(String.Empty, meme);
            
        }

        // DELETE: api/MyMemes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _collection.DeleteMeme(id);
            return NoContent();
        }
    }
}
