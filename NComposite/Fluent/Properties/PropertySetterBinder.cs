using System;
using System.Reflection;
using NComposite.Fluent.Properties.StateMapping;

namespace NComposite.Fluent.Properties
{
	public class PropertySetterBinder<TInterface, TState, TArg> : IPropertySetterBinder<TInterface, TState, TArg>
	{
		private readonly PropertyMapper<TInterface, TState> _propertyMapper;
		private readonly MethodInfo _setterMethod;

		public PropertySetterBinder(PropertyMapper<TInterface, TState> propertyMapper, MethodInfo setterMethod)
		{
			_propertyMapper = propertyMapper;
			_setterMethod = setterMethod;
		}

		public IPropertyMapper<TInterface, TState> Use(Action<IContext<TInterface, TState>, TArg> methodImplementation)
		{
			return _propertyMapper.Bind(_setterMethod, methodImplementation.Method);
		}
	}
}