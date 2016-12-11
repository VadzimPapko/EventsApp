using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.OS;
using Newtonsoft.Json;

namespace Event
{
	/// <summary>
	/// Zone activities presentor.
	/// </summary>
	public class ZoneActivitiesPresenter: BasePresenter
	{
		static string BUNDLE_ZONE_ACTIVITY_COLLECTION = "BUNDLE_ZONE_ACTIVITY_COLLECTION";

		IQueryable<ZoneActivityDto> _zoneActivityCollection;

		IZoneActivityView _view;

		public ZoneActivitiesPresenter(IZoneActivityView view)
		{
			_view = view;
		}

		public bool isZoneActivityCollectionNotEmpty()
		{
			return (_zoneActivityCollection != null && _zoneActivityCollection.Count() > 0);
		}

		public async void OnCreate(Bundle savedInstanceState, int zoneNumber)
		{
			if (savedInstanceState != null)
			{
				var savedData = savedInstanceState.GetString(BUNDLE_ZONE_ACTIVITY_COLLECTION);

				if (savedData != null)
					_zoneActivityCollection = JsonConvert.DeserializeObject<List<ZoneActivityDto>>(savedData).AsQueryable();
			}
			else
			{
				_zoneActivityCollection = await model.GetActivitiesByZone(zoneNumber);
			}

			if (isZoneActivityCollectionNotEmpty())
				_view.ShowZoneActivityCollection(_zoneActivityCollection);
			else
				_view.ShowEmptyCollection();
		}

		public void OnSaveInstanceState(Bundle outState)
		{
			if (isZoneActivityCollectionNotEmpty())
			{
				outState.PutString(BUNDLE_ZONE_ACTIVITY_COLLECTION, JsonConvert.SerializeObject(_zoneActivityCollection));
			}
		}
	}
}
