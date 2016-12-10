using Android.App;
using Android.Widget;
using Android.OS;
using PortableData;
using Android.Support.V7.Widget;
using Android.Views;
using System;
using Android.Content;
using System.Linq;

namespace Event
{
	[Activity(Label = "Zones", MainLauncher = false, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		IEventDataProvider _provider;

		IModel _model;

		RecyclerView mRecyclerView;

		RecyclerView.LayoutManager mLayoutManager;

		EventAdapter eventAdapter;

		protected override async void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			//Get EventDataProvider from Unity Container
			_provider = App.Container.Resolve(typeof(EventDataProvider), "eventDataProvider") as IEventDataProvider;

			//Initialization model
			_model = new Model(_provider);

			//Get ResyclerView layout:
			mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

			// Plug in the linear layout manager:
			mLayoutManager = new LinearLayoutManager(this);

			mRecyclerView.SetLayoutManager(mLayoutManager);

			var collection = await _model.GetZones();

			eventAdapter = new EventAdapter(collection);

			eventAdapter.ItemClick += OnItemClick;

			mRecyclerView.SetAdapter(eventAdapter);
		}

		// Handler for the item click event:
		void OnItemClick(object sender, int position)
		{
			var intent = new Intent(Application.Context, typeof(ZoneActivitiesActivity));

			intent.PutExtra("zoneNum", position);

			StartActivity(intent);
		}
	}

	public class EventViewHolder: RecyclerView.ViewHolder
	{
		public TextView Name { get; private set;}
		public TextView Description { get; private set;}

		public EventViewHolder(View itemView, Action<int> listener):base(itemView)
		{
			Name = itemView.FindViewById<TextView>(Resource.Id.txt_zone_name);
			Description = itemView.FindViewById<TextView>(Resource.Id.txt_zone_description);

			itemView.Click += (sender, e) => listener(AdapterPosition);
		}
	}

	//Adapter to connect Zones to the RecyclerView
	public class EventAdapter : RecyclerView.Adapter
	{
		public event EventHandler<int> ItemClick;

		ZoneDto[] _zoneDtos; 

		public EventAdapter(IQueryable<ZoneDto> zoneDtos)
		{
			_zoneDtos = zoneDtos.ToArray();
		}

		public override int ItemCount
		{
			get
			{
				return _zoneDtos.Count();
			}
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			EventViewHolder eventViewHolder = holder as EventViewHolder;

			eventViewHolder.Name.Text = _zoneDtos[position].Name;

			eventViewHolder.Description.Text = _zoneDtos[position].Description;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CardZone, parent, false);

			EventViewHolder eventViewHolder = new EventViewHolder(itemView, OnClick);

			return eventViewHolder;
		}

		void OnClick(int position)
		{
			if (ItemClick != null)
				ItemClick(this, position);
		}
	}
}

