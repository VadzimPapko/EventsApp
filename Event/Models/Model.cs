using PortableData;
using System.Threading.Tasks;
using System.Linq;

namespace Event
{
	/// <summary>
	/// This class is the part of MVP pattern implementation. M - model
	/// </summary>
	public class Model:IModel
	{
		IEventDataProvider _provider;

		public Model(IEventDataProvider provider)
		{
			_provider = provider;
		}

		/// <summary>
		/// Gets a collection of the Zones throw IEVentDataProvider that was implemented in PCL
		/// </summary>
		/// <returns>The zones.</returns>
		public async Task<IQueryable<ZoneDto>> GetZones()
		{
			var collection = await _provider.LoadZones();

			var query = from zone in collection
						select new ZoneDto { Name = zone.Name, Description = zone.Description }; //todo we can use AutoMapper here

			return query;
		}

		public async Task<IQueryable<ZoneActivityDto>> GetActivitiesByZone(int zoneNumber)
		{
			var zone = await _provider.FindZoneByNum(zoneNumber);

			var query = zone.Activities.Select(a => new ZoneActivityDto { Name = a.Name, StartTime = a.Start }).AsQueryable();

			return query;
		}

		/// <summary>
		/// Gets a collection of the Zone's Activities throw IEventDataProvider that was implemented in PCL.
		/// </summary>
		/// <returns>The zone activities.</returns>
		public async Task<IQueryable<ZoneActivityDto>> GetZoneActivities()
		{
			var collection = await _provider.LoadZoneActivities();

			var query = from activity in collection
				select new ZoneActivityDto { Name = activity.Name, StartTime = activity.Start };

			return query;
		}
	}
}
