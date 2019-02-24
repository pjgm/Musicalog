using ApplicationCore.Entities;
using System.Collections.Generic;

namespace Presentation.ViewModels
{
	public class InventoryViewModel
	{
		public IEnumerable<InventoryEntry> InventoryEntries { get; set; }
		public PaginationViewModel Pagination { get; set; }
	}
}
