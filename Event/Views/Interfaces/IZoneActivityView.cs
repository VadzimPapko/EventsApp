using System.Linq;

namespace Event
{
	public interface IZoneActivityView:IView
	{
		void ShowZoneActivityCollection(IQueryable<ZoneActivityDto> collection);
	}
}
