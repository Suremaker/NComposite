using System;
using System.Reflection;

namespace NComposite.Fluent.Properties.StateMapping
{
	public class StateMappings
	{
		//TODO: compile to static method
		public static Func<IContext<TInterface, TState>, TArg> GenerateGetter<TInterface, TState, TArg>(PropertyInfo stateProperty)
		{
			var getMethod = stateProperty.GetGetMethod();
			return ctx => (TArg)getMethod.Invoke(ctx.State, new object[0]);
		}

		public static Action<IContext<TInterface, TState>, TArg> GenerateSetter<TInterface, TState, TArg>(PropertyInfo stateProperty)
		{
			var setMethod = stateProperty.GetSetMethod();
			return (ctx, value) => setMethod.Invoke(ctx.State, new object[] { value });
		}
	}
}