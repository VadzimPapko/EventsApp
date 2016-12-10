using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PortableData
{
	/// <summary>
	/// Event data provider.
	/// </summary>
	public class EventDataProvider : IEventDataProvider
	{
		public async Task<Event> Load()
		{
			Event party;

			var stream = GetStream();

			if (stream == null) return null;

			using (var reader = new StreamReader(stream))
			{
				var json = await reader.ReadToEndAsync();

				party = JsonConvert.DeserializeObject<Event>(json);
			}

			return party;
		}

		public async Task<IQueryable<Zone>> LoadZones()
		{
			var stream = GetStream();

			if (stream == null) return null;

			var zones = new List<Zone>();

			using (var reader = new StreamReader(stream))
			{
				var json = await reader.ReadToEndAsync();

				var jsonObject = JObject.Parse(json);

				var jsonZones = jsonObject["Zones"].AsEnumerable();

				foreach (var item in jsonZones)
				{
					var zone = JsonConvert.DeserializeObject<Zone>(item.ToString());
					zones.Add(zone);
				}
			}

			return zones.AsQueryable();
		}

		public async Task<Zone> FindZoneByNum(int zoneNumber) 
		{
			var stream = GetStream();

			if (stream == null) return null;

			Zone zone;

			using (var reader = new StreamReader(stream)) 
			{
				var json = await reader.ReadToEndAsync();

				var jsonObject = JObject.Parse(json);

				var jsonZone = jsonObject["Zones"][zoneNumber];

				zone = JsonConvert.DeserializeObject<Zone>(jsonZone.ToString());
			}

			return zone;
		}

		public async Task<IQueryable<ZoneActivity>> LoadZoneActivities()
		{
			var stream = GetStream();

			if (stream == null) return null;

			var zoneActivities = new List<ZoneActivity>();

			using (var reader = new StreamReader(stream)) 
			{
				var json = await reader.ReadToEndAsync();

				var jsonObject = JObject.Parse(json);

				var jsonZoneActivities = jsonObject["Activities"].AsQueryable();

				foreach (var item in jsonZoneActivities)
				{
					var zoneActvity = JsonConvert.DeserializeObject<ZoneActivity>(item.ToString());
					zoneActivities.Add(zoneActvity);
				}
			}

			return zoneActivities.AsQueryable();
		}


		#region Get resource stream using reflection

		Stream GetStream() 
		{
			var assembly = typeof(EventDataProvider).GetTypeInfo().Assembly;

			var stream = assembly.GetManifestResourceStream("PortableData.Data.data.json");

			if (stream == null)
			{
				//todo we can log major invormation for us; for example "File data.json does not exists in PCL library"
				return null;
			}

			return stream;
		}

		#endregion
	}
}
