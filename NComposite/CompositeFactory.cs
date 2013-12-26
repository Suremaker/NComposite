using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using NComposite.Interfaces;

namespace NComposite
{
	public class CompositeFactory
	{
		private readonly IDictionary<Type, IComposite> _composites = new Dictionary<Type, IComposite>();
		private readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();

		public void LoadFrom(params Assembly[] assemblies)
		{
		}

		public void Load(params ICompositeMap[] maps)
		{
			foreach (var composite in maps.Select(m => m.Map()))
				_composites.Add(composite.Mapping.Interface, composite);
		}

		public T Create<T>() where T : class
		{
			IComposite composite;
			if (!_composites.TryGetValue(typeof(T), out composite))
				throw new InvalidOperationException(string.Format("No composite of {0} type is mapped", typeof(T)));

			return _proxyGenerator.CreateInterfaceProxyWithoutTarget<T>(new CompositeInterceptor(composite, _proxyGenerator));
		}
	}
}