using System.Reflection;

namespace NComposite.Fluent
{
	internal class MethodBinder<TInterface, TContext>
	{
		public MethodInfo InterfaceMethod { private get; set; }
		public MethodMapper<TInterface, TContext> MethodMapper { private get; set; }

		protected IMethodMapper<TInterface, TContext> Bind(MethodInfo implementation)
		{
			return MethodMapper.Map(InterfaceMethod, implementation);
		}
	}
}