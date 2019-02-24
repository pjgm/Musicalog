namespace ApplicationCore.Entities
{
    public class InventoryEntry : BaseEntity
	{
		public Album Album { get; set; }
        public int Stock { get; set; }
    }
}
