
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using PortableData;

namespace Event
{
	[Activity(Label = "Activities")]
	public class ZoneActivitiesActivity : Activity
	{
		const string ZONE_NUM = "zoneNum";

		IEventDataProvider _provider;

		IModel _model;

		RecyclerView _recyclerView;

		RecyclerView.LayoutManager _layoutManager;

		ZoneActivitiesAdapter _zoneActivitiesAdapter;

		protected override async void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			var zoneNum = Intent.GetIntExtra(ZONE_NUM, 0);

			SetContentView(Resource.Layout.ZoneActivities);

			//Get EventDataProvider from Unity Container
			_provider = App.Container.Resolve(typeof(EventDataProvider), "eventDataProvider") as IEventDataProvider;

			//Initialization model
			_model = new Model(_provider);

			//Get ResyclerView layout:
			_recyclerView = FindViewById<RecyclerView>(Resource.Id.activitiesRecyclerView);

			// Plug in the linear layout manager:
			_layoutManager = new LinearLayoutManager(this);

			_recyclerView.SetLayoutManager(_layoutManager);

			var activityCollection = await _model.GetActivitiesByZone(zoneNum);

			_zoneActivitiesAdapter = new ZoneActivitiesAdapter(activityCollection);

			_recyclerView.SetAdapter(_zoneActivitiesAdapter);
		}
	}

	public class ZoneActivitiesViewHolder : RecyclerView.ViewHolder 
	{
		public TextView Name { get; private set; }
		public TextView StartTime { get; private set;}

		public ZoneActivitiesViewHolder(View itemView):base(itemView)
		{
			Name = itemView.FindViewById<TextView>(Resource.Id.txt_activity_name);
			StartTime = itemView.FindViewById<TextView>(Resource.Id.txt_activity_start_time);
		}
	}

	public class ZoneActivitiesAdapter : RecyclerView.Adapter
	{
		IQueryable<ZoneActivityDto> _zoneActivityDtos;

		public ZoneActivitiesAdapter(IQueryable<ZoneActivityDto> zoneActivityDtos)
		{
			_zoneActivityDtos = zoneActivityDtos;
		}

		public override int ItemCount
		{
			get
			{
				return _zoneActivityDtos.Count();
			}
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			ZoneActivitiesViewHolder zoneActivitiesViewHolder = holder as ZoneActivitiesViewHolder;

			zoneActivitiesViewHolder.Name.Text = _zoneActivityDtos.ToArray()[position].Name;
			zoneActivitiesViewHolder.StartTime.Text = _zoneActivityDtos.ToArray()[position].StartTime;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CardZoneActivities, parent, false);

			ZoneActivitiesViewHolder zoneActivitiesViewHolder = new ZoneActivitiesViewHolder(itemView);

			return zoneActivitiesViewHolder;
		}
	}
}
