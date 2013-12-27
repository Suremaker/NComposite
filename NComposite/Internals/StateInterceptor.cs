using System.Collections.Generic;
using Castle.DynamicProxy;

namespace NComposite.Internals
{
	internal class StateInterceptor : IInterceptor
	{
		private readonly IDictionary<string, object> _properties = new Dictionary<string, object>();
		public void Intercept(IInvocation invocation)
		{
			var name = invocation.Method.Name;
			if (name.StartsWith("set_"))
				_properties[name.Substring(4)] = invocation.Arguments[0];
			else if (name.StartsWith("get_"))
			{
				object result;
				if (_properties.TryGetValue(name.Substring(4), out result))
					invocation.ReturnValue = result;
			}
		}
	}
}