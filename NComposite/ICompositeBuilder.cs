using System.Reflection;

namespace NComposite
{

	public interface IContext<TInterface, TState> { }

	public interface ICompositeBuilder<TInterface, TState>
	{
		void MapMethod(MethodInfo interfaceMethod, MethodInfo methodImplementation);
	}
}