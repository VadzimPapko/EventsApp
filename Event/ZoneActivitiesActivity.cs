using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;

namespace Event
{
	/// <summary>
	/// Zone activities activity.
	/// </summary>
	[Activity(Label = "Activities")]
	public class ZoneActivitiesActivity : Activity, IZoneActivityView
	{
		RecyclerView _recyclerView;

		RecyclerView.LayoutManager _layoutManager;

		ZoneActivitiesPresenter _presenter;

		ZoneActivitiesAdapter _zoneActivitiesAdapter;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			var zoneNum = Intent.GetIntExtra(Resource.String.zone_num.ToString(), 0);

			SetContentView(Resource.Layout.ZoneActivities);

			//Initialization presenter
			_presenter = new ZoneActivitiesPresenter(this);

			//Get ResyclerView layout:
			_recyclerView = FindViewById<RecyclerView>(Resource.Id.activitiesRecyclerView);

			// Plug in the linear layout manager:
			_layoutManager = new LinearLayoutManager(this);

			_recyclerView.SetLayoutManager(_layoutManager);

			_presenter.OnCreate(savedInstanceState, zoneNum);
		}

		/// <summary>
		/// Shows the zone activity collection.
		/// </summary>
		/// <param name="collection">Collection.</param>
		public void ShowZoneActivityCollection(IQueryable<ZoneActivityDto> collection)
		{
			_zoneActivitiesAdapter = new ZoneActivitiesAdapter(collection);

			_recyclerView.SetAdapter(_zoneActivitiesAdapter);
		}

		/// <summary>
		/// Shows the empty collection.
		/// </summary>
		public void ShowEmptyCollection()
		{
			Toast.MakeText(this, Resource.String.emty_zone_activities_list, ToastLength.Short).Show();
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);

			_presenter.OnSaveInstanceState(outState);
		}
	}
}
