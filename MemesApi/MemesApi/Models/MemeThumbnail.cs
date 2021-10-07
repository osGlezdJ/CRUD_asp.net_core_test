namespace MemesApi.Models
{
    public class MemeThumbnail
    {
        public int MemeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Original { get; set; }
        public string Thumb { get; set; }
    }
}