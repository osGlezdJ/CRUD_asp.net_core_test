using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MemesApi.Controllers;
using MemesApi.Models;
using Xunit;

namespace TestForMemesApi
{
    [Collection("TestResources collection")]
    public class ListControllerShould
    {
        private readonly CreateResources _res;
        

        public ListControllerShould(CreateResources resources)
        {
            _res = resources;
        }
        
        [Fact]
        public void InitCorrectly()
        {
            //Assert.Equal(4, _res.Meme.MyList.Count);
            Assert.NotEmpty(_res.Meme.MyList);
        }

        [Fact]
        public void Create()
        {
            _res.Meme.AddItem(_res.Th);
            var ff = _res.Meme.MyList.FirstOrDefault(m => m.Name == "Test meme");

           Assert.Contains(ff, _res.Meme.MyList);

        }
    }
}