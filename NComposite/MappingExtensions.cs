using System;
using System.Reflection;
using NComposite.Fluent;

namespace NComposite
{
	public static class MappingExtensions
	{
		public static void MapAction<TInterface, TState>(
			this ICompositeBuilder<TInterface, TState> builder,
			Func<IActionMapper<TInterface, IContext<TInterface, TState>>, Tuple<MethodInfo, MethodInfo>> mapping)
		{
			var mapper = new ActionMapper<TInterface, IContext<TInterface, TState>>();
			var tuple = mapping(mapper);
			builder.MapMethod(tuple.Item1, tuple.Item2);
		}

		public static void MapMethod<TInterface, TState>(
			this ICompositeBuilder<TInterface, TState> builder,
			Func<IMethodMapper<TInterface, IContext<TInterface, TState>>, Tuple<MethodInfo, MethodInfo>> mapping)
		{
			var mapper = new MethodMapper<TInterface, IContext<TInterface, TState>>();
			var tuple = mapping(mapper);
			builder.MapMethod(tuple.Item1, tuple.Item2);
		}
	}
}