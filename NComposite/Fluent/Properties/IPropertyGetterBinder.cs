using System;

namespace NComposite.Fluent.Properties
{
	public interface IPropertyGetterBinder<TInterface, TState, in TArg>
	{
		IPropertyMapper<TInterface, TState> Use(Func<IContext<TInterface, TState>, TArg> methodImplementation);
	}
}