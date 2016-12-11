using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Event
{
	public class ZoneActivitiesAdapter: RecyclerView.Adapter
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

		public class ZoneActivitiesViewHolder : RecyclerView.ViewHolder
		{
			public TextView Name { get; private set; }
			public TextView StartTime { get; private set; }

			public ZoneActivitiesViewHolder(View itemView) : base(itemView)
			{
				Name = itemView.FindViewById<TextView>(Resource.Id.txt_activity_name);
				StartTime = itemView.FindViewById<TextView>(Resource.Id.txt_activity_start_time);
			}
		}
	}
}
