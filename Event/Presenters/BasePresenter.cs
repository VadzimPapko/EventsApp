using PortableData;
using Java.Lang;

namespace Event
{
	/// <summary>
	/// Base presentor.
	/// </summary>
	public abstract class BasePresenter
	{
		protected IModel model;

		IEventDataProvider _provider;

		public BasePresenter()
		{
			_provider = App.Container.Resolve(typeof(EventDataProvider), "eventDataProvider") as IEventDataProvider;

			model = new Model(_provider);
		}
	}
}
