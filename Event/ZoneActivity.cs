using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Content;
using Android.Widget;
using System.Linq;

namespace Event
{
	/// <summary>
	/// Zone activity.
	/// </summary>
	[Activity(Label = "Zones", MainLauncher = false, Icon = "@mipmap/icon")]
	public class ZoneActivity : Activity, IZoneView
	{
		RecyclerView _recyclerView;

		RecyclerView.LayoutManager _layoutManager;

		ZonesPresenter _presenter;

		ZonesAdapter _zonesAdapter;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			//Initialization presenter
			_presenter = new ZonesPresenter(this);

			//Get ResyclerView layout:
			_recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

			// Plug in the linear layout manager:
			_layoutManager = new LinearLayoutManager(this);

			_recyclerView.SetLayoutManager(_layoutManager);

			_presenter.OnCreate(savedInstanceState);
		}

		// Handler for the item click event:
		void OnItemClick(object sender, int position)
		{
			_presenter.OnItemClick(position);
		}

		/// <summary>
		/// Shows the zone collection.
		/// </summary>
		/// <param name="collection">IQueryable zone collection</param>
		public void ShowZoneCollection(IQueryable<ZoneDto> collection)
		{
			_zonesAdapter = new ZonesAdapter(collection);

			_zonesAdapter.ItemClick += OnItemClick;

			_recyclerView.SetAdapter(_zonesAdapter);
		}

		/// <summary>
		/// Shows the empty collection.
		/// </summary>
		public void ShowEmptyCollection()
		{
			Toast.MakeText(this, Resource.String.emty_zones_list, ToastLength.Short).Show();
		}

		/// <summary>
		/// Starts the new activity.
		/// </summary>
		/// <param name="intent">Intent object</param>
		public void StartNewActivity(Intent intent)
		{
			StartActivity(intent);
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);

			_presenter.OnSaveInstanceState(outState);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
		}
	}
}

