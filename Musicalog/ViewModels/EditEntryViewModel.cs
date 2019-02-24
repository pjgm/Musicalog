using ApplicationCore.Entities;
using System.Collections.Generic;

namespace Presentation.ViewModels
{
	public class EditEntryViewModel
	{
		public IEnumerable<AlbumType> AlbumTypes { get; set; }
		public InventoryEntry Entry { get; set; }
	}
}
