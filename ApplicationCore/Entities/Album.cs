﻿namespace ApplicationCore.Entities
{
    public class Album : BaseEntity
	{
		public string Name { get; set; }
		public AlbumType Type { get; set; }
		public Artist Artist { get; set; }
        public RecordLabel RecordLabel { get; set; }
    }
}
