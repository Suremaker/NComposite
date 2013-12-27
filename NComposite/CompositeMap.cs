using NComposite.Interfaces;
using NComposite.Internals;

namespace NComposite
{
	public abstract class CompositeMap<TInterface, TState> : ICompositeMap
	{
		public IComposite Map()
		{
			var builder = new CompositeBuilder<TInterface, TState>();
			Map(builder);
			return builder.Build();
		}

		protected abstract void Map(ICompositeBuilder<TInterface, TState> builder);
	}

	public interface INoState { }

	public abstract class CompositeMap<TInterface> : CompositeMap<TInterface, INoState> { }
}
