﻿using ApplicationCore.Entities;
using Dapper.FluentMap.Mapping;

namespace Infrastructure.Mapping
{
	internal class RecordLabelMap : EntityMap<RecordLabel>
	{
		internal RecordLabelMap()
		{
			Map(recordLabel => recordLabel.Name).ToColumn("RecordLabelName");
		}
	}
}
