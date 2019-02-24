using ApplicationCore.Entities;
using ApplicationCore.Exceptions;

namespace ApplicationCore.Validators
{
	public static class InventoryEntryValidator
	{
		public const int MaxStringSize = 255;
		public static void Validate(InventoryEntry entry)
		{
			if (entry.Album == null || entry.Album.Artist == null || entry.Album.RecordLabel == null)
			{
				throw new InvalidInputValueException("Input value not defined");
			}
			if (entry.Stock < 0)
			{
				throw new InvalidInputValueException("Negative input now allowed");
			}
			if (entry.Album.Artist.Name.Length > MaxStringSize)
			{
				throw new InvalidInputValueException("Artist name is too long");
			}
			if (entry.Album.RecordLabel.Name.Length > MaxStringSize)
			{
				throw new InvalidInputValueException("Record label name is too long");
			}
			if (entry.Album.Name.Length > MaxStringSize)
			{
				throw new InvalidInputValueException("Album name is too long");
			}
		}
	}
}
