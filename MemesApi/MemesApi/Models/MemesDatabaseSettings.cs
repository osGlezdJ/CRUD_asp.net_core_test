namespace MemesApi.Models
{
    public class MemesDatabaseSettings : IMemesDatabaseSettings
    {
        public string MemesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}