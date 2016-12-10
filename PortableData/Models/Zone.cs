namespace PortableData
{
	public sealed class Zone
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public ZoneActivity[] Activities { get; set; }

		public override string ToString()
		{
			return $"[Zone: Name={Name}, Description={Description}, Activities={Activities}]";
		}
	}
}
