using System;
using System.Linq.Expressions;
using NComposite.Fluent.Properties.StateMapping;

namespace NComposite.Fluent.Properties
{
	public interface IPropertyMapper<TInterface, TState>
	{
		IPropertyGetterBinder<TInterface, TState, TArg> ForGetter<TArg>(Expression<Func<TInterface, TArg>> interfacePropertySelector);
		IPropertySetterBinder<TInterface, TState, TArg> ForSetter<TArg>(Action<TInterface, TArg> interfacePropertySetterSelector);
	}
}