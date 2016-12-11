using System;

namespace Event
{
	/// <summary>
	/// This class is the Data Transfer Object of the PortableData.Models.Zone.cs.
	/// </summary>
	[Serializable]
	public sealed class ZoneDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
