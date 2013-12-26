using System.Reflection;

namespace NComposite
{
	public interface IContext<TInterface, TState>
	{
		TState State { get; }
	}

	internal class Context<TInterface, TState> : IContext<TInterface, TState>
	{
		public Context(TState state)
		{
			State = state;
		}

		public TState State { get; private set; }
	}

	public interface ICompositeBuilder<TInterface, TState>
	{
		void MapMethod(MethodInfo interfaceMethod, MethodInfo methodImplementation);
	}
}