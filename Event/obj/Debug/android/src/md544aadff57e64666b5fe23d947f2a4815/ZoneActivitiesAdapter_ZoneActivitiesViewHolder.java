package md544aadff57e64666b5fe23d947f2a4815;


public class ZoneActivitiesAdapter_ZoneActivitiesViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Event.ZoneActivitiesAdapter+ZoneActivitiesViewHolder, Event, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ZoneActivitiesAdapter_ZoneActivitiesViewHolder.class, __md_methods);
	}


	public ZoneActivitiesAdapter_ZoneActivitiesViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == ZoneActivitiesAdapter_ZoneActivitiesViewHolder.class)
			mono.android.TypeManager.Activate ("Event.ZoneActivitiesAdapter+ZoneActivitiesViewHolder, Event, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
