namespace PortableData
{
	public sealed class Event
	{
		public Zone[] Zones { get; set; }
		public string Title { get; set; }
		public string InstaTag { get; set; }

		public override string ToString()
		{
			return $"[Event: Zones={Zones}, Title={Title}, InstaTag={InstaTag}]";
		}
	}
}
