namespace ApplicationCore.Entities
{
    public class Album
    {
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public AlbumType Type { get; set; }
        public RecordLabel RecordLabel { get; set; }
    }
}
