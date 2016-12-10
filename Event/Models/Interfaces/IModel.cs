using System.Linq;
using System.Threading.Tasks;

namespace Event
{
	/// <summary>
	/// General interface IModel for Model in MVP architecture
	/// </summary>
	public interface IModel
	{
		Task<IQueryable<ZoneDto>> GetZones();

		Task<IQueryable<ZoneActivityDto>> GetActivitiesByZone(int zoneNumber);

		Task<IQueryable<ZoneActivityDto>> GetZoneActivities();
	}
}
