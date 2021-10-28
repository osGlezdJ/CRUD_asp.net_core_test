namespace MemesApi.Models
{
    public interface IMemesDatabaseSettings
    {
        public string MemesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}