using System;
using Android.App;
using Android.Runtime;
using Android.Content;
using Microsoft.Practices.Unity;
using PortableData;
namespace Event
{
	[Application(Icon = "@mipmap/icon")]
	public class App:Application
	{
		static Context context;

		public static UnityContainer Container { get; set; }

		public App(IntPtr h, JniHandleOwnership jho): base(h, jho)
		{
		}

		public override void OnCreate()
		{
			Container = new UnityContainer();

			Container.RegisterType<IEventDataProvider, EventDataProvider>();

			base.OnCreate();

			context = Application.Context;
		}

		//get current application context
		public static Context getAppContext() 
		{
			return context;
		}
	}
}
