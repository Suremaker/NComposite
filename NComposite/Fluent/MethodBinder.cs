using System;
using System.Reflection;

namespace NComposite.Fluent
{
	internal class MethodBinder
	{
		public MethodInfo InterfaceMethod { private get; set; }

		protected Tuple<MethodInfo, MethodInfo> Bind(MethodInfo implementation)
		{
			return Tuple.Create(InterfaceMethod, implementation);
		}
	}
}