using System;
using System.Reflection;

namespace NComposite.Fluent.Properties
{
	public class PropertyGetterBinder<TInterface, TState, TArg> : IPropertyGetterBinder<TInterface, TState, TArg>
	{
		private readonly PropertyMapper<TInterface, TState> _propertyMapper;
		private readonly MethodInfo _getterMethod;

		public PropertyGetterBinder(PropertyMapper<TInterface, TState> propertyMapper, MethodInfo getterMethod)
		{
			_propertyMapper = propertyMapper;
			_getterMethod = getterMethod;
		}

		public IPropertyMapper<TInterface, TState> Use(Func<IContext<TInterface, TState>, TArg> methodImplementation)
		{
			return _propertyMapper.Bind(_getterMethod, methodImplementation.Method);
		}
	}
}