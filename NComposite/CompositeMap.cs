using NComposite.Interfaces;

namespace NComposite
{
	/*public class ClassMap<TInterface, TState> : IClassMap
	{
		protected void MapPropertyGet<TArg>(Expression<Func<TInterface, TArg>> property, Func<IContext<TInterface, TState>, TArg> impl)
		{

		}
		protected void MapPropertySet<TArg>(Expression<Func<TInterface, TArg>> property, Action<IContext<TInterface, TState>, TArg> impl)
		{

		}
		protected void MapMethod<TArg>(Expression<Func<TInterface, Action<TArg>>> method, Action<IContext<TInterface, TState>, TArg> impl)
		{

		}
	}*/

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
