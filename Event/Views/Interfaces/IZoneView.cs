using System.Linq;
using Android.Content;
namespace Event
{
	public interface IZoneView:IView
	{
		void ShowZoneCollection(IQueryable<ZoneDto> collection);

		void StartNewActivity(Intent intent);
	}
}
