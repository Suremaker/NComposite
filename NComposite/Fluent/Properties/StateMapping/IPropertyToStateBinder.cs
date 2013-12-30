using System;
using System.Linq.Expressions;

namespace NComposite.Fluent.Properties.StateMapping
{
	public interface IPropertyToStateBinder<TInterface, TState, TArg>
	{
		IPropertyMapper<TInterface, TState> UseStateProperty(Expression<Func<TState, TArg>> statePropertySelector);
	}
}