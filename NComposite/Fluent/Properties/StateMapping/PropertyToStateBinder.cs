using System;
using System.Linq.Expressions;
using System.Reflection;
using LambdaReflection;

namespace NComposite.Fluent.Properties.StateMapping
{
	public class PropertyToStateBinder<TInterface, TState, TArg> : IPropertyToStateBinder<TInterface, TState, TArg>
	{
		private readonly PropertyMapper<TInterface, TState> _mapper;
		private readonly PropertyInfo _interfaceProperty;

		public PropertyToStateBinder(PropertyMapper<TInterface, TState> mapper, PropertyInfo interfaceProperty)
		{
			_mapper = mapper;
			_interfaceProperty = interfaceProperty;
		}

		public IPropertyMapper<TInterface, TState> UseStateProperty(Expression<Func<TState, TArg>> statePropertySelector)
		{
			if(_interfaceProperty.GetGetMethod()!=null)
				_mapper.Bind(_interfaceProperty.GetGetMethod(), StateMappings.GenerateGetter<TInterface, TState, TArg>(statePropertySelector.PropertyFromGetter()).Method);
			if(_interfaceProperty.GetSetMethod()!=null)
				_mapper.Bind(_interfaceProperty.GetSetMethod(), StateMappings.GenerateSetter<TInterface, TState, TArg>(statePropertySelector.PropertyFromGetter()).Method);
			return _mapper;
		}
	}
}