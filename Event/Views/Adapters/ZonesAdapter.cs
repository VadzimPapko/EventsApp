using System;
using Android.Support.V7.Widget;
using Android.Views;
using System.Linq;
using Android.Widget;

namespace Event
{
	public class ZonesAdapter: RecyclerView.Adapter
	{
		public event EventHandler<int> ItemClick;

		IQueryable<ZoneDto> _zoneDtos;

		public ZonesAdapter(IQueryable<ZoneDto> zoneDtos)
		{
			_zoneDtos = zoneDtos;
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
			ZoneViewHolder zoneViewHolder = holder as ZoneViewHolder;

			zoneViewHolder.Name.Text = _zoneDtos.ToArray()[position].Name;

			zoneViewHolder.Description.Text = _zoneDtos.ToArray()[position].Description;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CardZone, parent, false);

			ZoneViewHolder zoneViewHolder = new ZoneViewHolder(itemView, OnClick);

			return zoneViewHolder;
		}

		void OnClick(int position)
		{
			if (ItemClick != null)
				ItemClick(this, position);
		}

		public class ZoneViewHolder : RecyclerView.ViewHolder
		{
			public TextView Name { get; private set; }
			public TextView Description { get; private set; }

			public ZoneViewHolder(View itemView, Action<int> listener) : base(itemView)
			{
				Name = itemView.FindViewById<TextView>(Resource.Id.txt_zone_name);
				Description = itemView.FindViewById<TextView>(Resource.Id.txt_zone_description);

				itemView.Click += (sender, e) => listener(AdapterPosition);
			}
		}
	}
}
