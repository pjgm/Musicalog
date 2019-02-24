using System;

namespace ApplicationCore.Exceptions
{
	public class InventoryEntryNotFoundException : Exception
	{
		public InventoryEntryNotFoundException(string message) : base(message)
		{
		}
	}
}
