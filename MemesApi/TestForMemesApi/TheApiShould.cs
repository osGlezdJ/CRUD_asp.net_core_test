using System.Linq;
using Xunit;

namespace TestForMemesApi
{
    [Collection("TestResources collection")]
    public class TheApiShould
    {
        private readonly CreateResources _res;
        

        public TheApiShould(CreateResources resources)
        {
            _res = resources;
        }
        
        
        [Fact]
        public void InitCorrectly()
        {
            Assert.NotEmpty(_res.Meme.MyList);
        }

        [Fact]
        public void CreateItem()
        {
            _res.Meme.AddItem(_res.Th);
            var ff = _res.Meme.MyList.FirstOrDefault(m => m.Name == "Test meme");

           Assert.Contains(ff, _res.Meme.MyList);

        }
        
        [Fact]
        public void GetItemById()
        {
            Assert.NotStrictEqual(_res.Meme.GetMemeById(0), _res.Temp1);
        }
        
        [Fact]
        public void PutItem()
        {
            _res.Meme.MyList[0] = _res.Temp2;
            Assert.Equal(_res.Meme.GetMemeById(0), _res.Temp2);
            Assert.NotEqual(_res.Meme.GetMemeById(0), _res.Temp1);
        }
        
        [Fact]
        public void DeleteItem()
        {
            var counter = _res.Meme.MyList.Count - 1;
            _res.Meme.MyList.RemoveAt(1);
            
            Assert.Equal(counter, _res.Meme.MyList.Count );
            
        }
        
    }
}