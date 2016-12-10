namespace PortableData
{
	public sealed class ZoneActivity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string LongDescription { get; set; }
		public string Start { get; set; }
		public string End { get; set; }

		public override string ToString()
		{
			return $"[ZoneActivity: Name={Name}, Description={Description}, LongDescription={LongDescription}, " +
				"Start={Start}, End={End}]";
		}
	}
}
