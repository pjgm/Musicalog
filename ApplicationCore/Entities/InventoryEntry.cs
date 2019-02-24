namespace ApplicationCore.Entities
{
    public class InventoryEntry
    {
		public int Id { get; set; }
		public Album Album { get; set; }
        public int Stock { get; set; }
    }
}
