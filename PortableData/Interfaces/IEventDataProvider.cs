using System.Threading.Tasks;
using System.Linq;
namespace PortableData
{
	public interface IEventDataProvider
	{
		Task<Event> Load();

		Task<IQueryable<Zone>> LoadZones();

		Task<Zone> FindZoneByNum(int zoneNumber);

		Task<IQueryable<ZoneActivity>> LoadZoneActivities();
	}
}
