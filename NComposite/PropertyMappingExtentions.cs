using System;
using System.Linq.Expressions;
using NComposite.Fluent.Properties;
using NComposite.Fluent.Properties.StateMapping;
using NComposite.Helpers;

namespace NComposite
{
	public static class PropertyMappingExtentions
	{
		public static IPropertyToStateBinder<TInterface, TState, TArg> For<TInterface, TState, TArg>(
			this IPropertyMapper<TInterface, TState> mapper,
			Expression<Func<TInterface, TArg>> interfacePropertySelector)
		{
			//TODO: refactor
			return new PropertyToStateBinder<TInterface, TState, TArg>((PropertyMapper<TInterface, TState>)mapper, interfacePropertySelector.PropertyGetterCallToProperty());
		}

		public static IPropertyMapper<TInterface, TState> UseStateProperty<TInterface, TState, TArg>(this IPropertyGetterBinder<TInterface, TState, TArg> binder, Expression<Func<TState, TArg>> statePropertySelector)
		{
			return binder.Use(StateMappings.GenerateGetter<TInterface, TState, TArg>(statePropertySelector.PropertyGetterCallToProperty()));
		}

		public static IPropertyMapper<TInterface, TState> UseStateProperty<TInterface, TState, TArg>(this IPropertySetterBinder<TInterface, TState, TArg> binder, Expression<Func<TState, TArg>> statePropertySelector)
		{
			return binder.Use(StateMappings.GenerateSetter<TInterface, TState, TArg>(statePropertySelector.PropertyGetterCallToProperty()));
		}
	}
}