using System;

namespace NComposite.Fluent
{
	internal class ActionBinder<TInterface, TContext, TArg> : MethodBinder<TInterface, TContext>, IActionBinder<TInterface, TContext, TArg>
	{
		public IMethodMapper<TInterface, TContext> Use(Action<TContext, TArg> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class ActionBinder<TInterface, TContext> : MethodBinder<TInterface, TContext>, IActionBinder<TInterface, TContext>
	{
		public IMethodMapper<TInterface, TContext> Use(Action<TContext> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class ActionBinder<TInterface, TContext, TArg1, TArg2> : MethodBinder<TInterface, TContext>, IActionBinder<TInterface, TContext, TArg1, TArg2>
	{
		public IMethodMapper<TInterface, TContext> Use(Action<TContext, TArg1, TArg2> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class ActionBinder<TInterface, TContext, TArg1, TArg2, TArg3> : MethodBinder<TInterface, TContext>, IActionBinder<TInterface, TContext, TArg1, TArg2, TArg3>
	{
		public IMethodMapper<TInterface, TContext> Use(Action<TContext, TArg1, TArg2, TArg3> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class ActionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4> : MethodBinder<TInterface, TContext>, IActionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4>
	{
		public IMethodMapper<TInterface, TContext> Use(Action<TContext, TArg1, TArg2, TArg3, TArg4> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class ActionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TArg5> : MethodBinder<TInterface, TContext>, IActionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TArg5>
	{
		public IMethodMapper<TInterface, TContext> Use(Action<TContext, TArg1, TArg2, TArg3, TArg4, TArg5> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}
}