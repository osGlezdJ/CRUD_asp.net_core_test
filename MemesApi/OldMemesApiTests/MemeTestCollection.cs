using Xunit;

namespace TestForMemesApi
{
    [CollectionDefinition("TestResources collection")]
    public class MemeTestCollection : ICollectionFixture<CreateResources> {}
}