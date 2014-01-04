using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NComposite.Interfaces;

namespace NComposite.Internals
{
	internal class CompositeBuilder<TInterface, TState> : ICompositeBuilder<TInterface, TState>
	{
		private readonly IDictionary<MethodInfo, MethodInfo> _methods = new Dictionary<MethodInfo, MethodInfo>();

		public IComposite Build()
		{
			Validate();
			return new Composite(
				new TypeMapping(typeof(TInterface), typeof(TState), _methods),
				new TypeMapping[0],
				new Type[0]);
		}

		private void Validate()
		{
			var missingMethods = typeof(TInterface).GetMethods().Where(m => !_methods.ContainsKey(m)).OrderBy(m => m.Name).ToArray();
			if (missingMethods.Length > 0)
				throw new InvalidOperationException(string.Format("{0} mapping is incomplete:\n{1}",
					typeof(TInterface).FullName,
					string.Join("\n", missingMethods.Select(m => "Missing mapping for: " + m))));
		}

		public void MapMethod(MethodInfo interfaceMethod, MethodInfo methodImplementation)
		{
			if (interfaceMethod == null || methodImplementation == null)
				throw new ArgumentException(string.Format("Interface and implementation method has to be specified.\nInterface={0},\nImplementation={1}", interfaceMethod, methodImplementation));
			if (!typeof(TInterface).IsAssignableFrom(interfaceMethod.DeclaringType))
				throw new ArgumentException("Interface method has to be declared within interface type.");
			if (!methodImplementation.IsStatic)
				throw new ArgumentException("Method implementation has to refer to static method");

			if (interfaceMethod.ReturnType != methodImplementation.ReturnType)
				throw new ArgumentException("Return type of interface method and method implementation have to match");

			if (!CheckContextParameter(methodImplementation.GetParameters().FirstOrDefault()))
				throw new ArgumentException(string.Format("Method implementation first parameter has to be {0}", typeof(IContext<TInterface, TState>).FullName));
			CheckMethodParameters(interfaceMethod.GetParameters(), methodImplementation.GetParameters().Skip(1).ToArray());

			_methods[interfaceMethod] = methodImplementation;
		}

		private void CheckMethodParameters(ParameterInfo[] interfaceParams, ParameterInfo[] implementationParams)
		{
			if (interfaceParams.Length != implementationParams.Length)
				throw new ArgumentException(string.Format("Method implementation signature has to match to interface method"));

			if (interfaceParams.Where((t, i) => t.ParameterType != implementationParams[i].ParameterType || t.IsOut != implementationParams[i].IsOut).Any())
				throw new ArgumentException(string.Format("Method implementation signature has to match to interface method"));
		}

		bool CheckContextParameter(ParameterInfo parameter)
		{
			return parameter != null && parameter.ParameterType == typeof(IContext<TInterface, TState>) && !parameter.IsOut;
		}
	}

	internal class Composite : IComposite
	{
		public Composite(TypeMapping mapping, TypeMapping[] extensions, Type[] inheritedTypes)
		{
			InheritedTypes = inheritedTypes;
			Extensions = extensions;
			Mapping = mapping;
		}

		public TypeMapping Mapping { get; private set; }
		public TypeMapping[] Extensions { get; private set; }
		public Type[] InheritedTypes { get; private set; }
	}
}