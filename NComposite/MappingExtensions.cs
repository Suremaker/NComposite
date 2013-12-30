using NComposite.Fluent.Methods;
using NComposite.Fluent.Properties;

namespace NComposite
{
	public static class MappingExtensions
	{
		public static IMethodMapper<TInterface, IContext<TInterface, TState>> MapMethods<TInterface, TState>(
			this ICompositeBuilder<TInterface, TState> builder)
		{
			return new MethodMapper<TInterface, IContext<TInterface, TState>>(builder);
		}

		public static IPropertyMapper<TInterface, TState> MapProperties<TInterface, TState>(
			this ICompositeBuilder<TInterface, TState> builder)
		{
			return new PropertyMapper<TInterface, TState>(builder);
		}
	}
}