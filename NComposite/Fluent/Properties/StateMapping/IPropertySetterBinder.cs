using System;

namespace NComposite.Fluent.Properties.StateMapping
{
	public interface IPropertySetterBinder<TInterface, TState, out TArg>
	{
		IPropertyMapper<TInterface, TState> Use(Action<IContext<TInterface, TState>, TArg> methodImplementation);
	}
}