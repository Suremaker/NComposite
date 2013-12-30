using System;
using System.Linq.Expressions;
using System.Reflection;
using DelegateDecompiler;
using NComposite.Fluent.Properties.StateMapping;
using NComposite.Helpers;

namespace NComposite.Fluent.Properties
{
	public class PropertyMapper<TInterface, TState> : IPropertyMapper<TInterface, TState>
	{
		private readonly ICompositeBuilder<TInterface, TState> _builder;

		public PropertyMapper(ICompositeBuilder<TInterface, TState> builder)
		{
			_builder = builder;
		}

		public IPropertyGetterBinder<TInterface, TState, TArg> ForGetter<TArg>(Expression<Func<TInterface, TArg>> interfacePropertySelector)
		{
			return new PropertyGetterBinder<TInterface, TState, TArg>(this, interfacePropertySelector.PropertyGetterCallToProperty().GetGetMethod());
		}

		public IPropertySetterBinder<TInterface, TState, TArg> ForSetter<TArg>(Action<TInterface, TArg> interfacePropertySetterSelector)
		{
			return new PropertySetterBinder<TInterface, TState, TArg>(this, interfacePropertySetterSelector.Decompile().MethodCallToMethodInfo());
		}

		internal IPropertyMapper<TInterface, TState> Bind(MethodInfo interfaceMethod, MethodInfo implementationMethod)
		{
			_builder.MapMethod(interfaceMethod, implementationMethod);
			return this;
		}
	}
}