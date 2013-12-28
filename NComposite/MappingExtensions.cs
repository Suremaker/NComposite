using NComposite.Fluent;

namespace NComposite
{
	public static class MappingExtensions
	{
		public static IMethodMapper<TInterface, IContext<TInterface, TState>> MapMethods<TInterface, TState>(this ICompositeBuilder<TInterface, TState> builder)
		{
			return new MethodMapper<TInterface, IContext<TInterface, TState>>(builder);
		}
	}
}