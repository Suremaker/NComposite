using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using NComposite.Interfaces;

namespace NComposite
{
	public class CompositeInterceptor : IInterceptor
	{
		private readonly IComposite _composite;
		private object _state;

		public CompositeInterceptor(IComposite composite, ProxyGenerator proxyGenerator)
		{
			_composite = composite;
			_state = CreateState(proxyGenerator);
		}

		private object CreateState(ProxyGenerator proxyGenerator)
		{
			return proxyGenerator.CreateInterfaceProxyWithoutTarget(
				_composite.Mapping.State,
				_composite.Extensions.Select(e => e.State).ToArray(),
				new StateInterceptor());
		}

		public void Intercept(IInvocation invocation)
		{
			var binding = FindBinding(invocation.Method);
			invocation.ReturnValue = binding.Invoke(null, PrepareArguments(binding, invocation));
		}

		private object[] PrepareArguments(MethodInfo binding, IInvocation invocation)
		{
			object ctx = CreateContext(binding.GetParameters().First().ParameterType.GetGenericArguments());

			return Enumerable.Repeat(ctx, 1).Concat(invocation.Arguments).ToArray();
		}

		private object CreateContext(Type[] genericArguments)
		{
			return Activator.CreateInstance(typeof(Context<,>).MakeGenericType(genericArguments), _state);
		}

		private MethodInfo FindBinding(MethodInfo method)
		{
			return _composite.Mapping.MethodBindings
				.Concat(_composite.Extensions.SelectMany(e => e.MethodBindings))
				.First(b => b.Key == method).Value;
		}
	}
}