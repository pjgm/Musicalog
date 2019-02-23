namespace ApplicationCore.Entities
{
    public class Album
    {
        public string Name { get; set; }
		public int Type { get; set; }
		public Artist Artist { get; set; }
        public RecordLabel RecordLabel { get; set; }
    }
}
