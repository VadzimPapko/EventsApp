using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Newtonsoft.Json;
using System.Linq;
namespace Event
{
	/// <summary>
	/// Zones presenter.
	/// </summary>
	public class ZonesPresenter:BasePresenter
	{
		static string BUNDLE_ZONE_COLLECTION = "BUNDLE_ZONE_COLLECTION";

		IQueryable<ZoneDto> _zoneCollection;

		IZoneView _view;

		public ZonesPresenter(IZoneView view)
		{
			_view = view;
		}

		public bool isZoneCollectionNotEmpty()
		{
			return (_zoneCollection != null && _zoneCollection.Count() > 0);
		}

		public async void OnCreate(Bundle savedInstanceState) 
		{
			if (savedInstanceState != null)
			{
				var savedData = savedInstanceState.GetString(BUNDLE_ZONE_COLLECTION);

				if (savedData != null)
					_zoneCollection = JsonConvert.DeserializeObject<List<ZoneDto>>(savedData).AsQueryable();
			}
			else 
			{ 
				_zoneCollection = await model.GetZones(); 
			}

			if (isZoneCollectionNotEmpty())
				_view.ShowZoneCollection(_zoneCollection);
			else
				_view.ShowEmptyCollection();
		}

		public void OnItemClick(int position)
		{
			var intent = new Intent(Application.Context, typeof(ZoneActivitiesActivity));

			intent.PutExtra(Resource.String.zone_num.ToString(), position);

			_view.StartNewActivity(intent);
		}

		public void OnSaveInstanceState(Bundle outState)
		{
			if (isZoneCollectionNotEmpty())
			{
				outState.PutString(BUNDLE_ZONE_COLLECTION, JsonConvert.SerializeObject(_zoneCollection));
			}
		}
	}
}
