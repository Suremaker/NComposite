using System;

namespace NComposite.Fluent.Methods
{
	internal class FunctionBinder<TInterface, TContext, TResult> : MethodBinder<TInterface, TContext>, IFunctionBinder<TInterface, TContext, TResult>
	{
		public IMethodMapper<TInterface, TContext> Use(Func<TContext, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class FunctionBinder<TInterface, TContext, TArg, TResult> : MethodBinder<TInterface, TContext>, IFunctionBinder<TInterface, TContext, TArg, TResult>
	{
		public IMethodMapper<TInterface, TContext> Use(Func<TContext, TArg, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class FunctionBinder<TInterface, TContext, TArg1, TArg2, TResult> : MethodBinder<TInterface, TContext>, IFunctionBinder<TInterface, TContext, TArg1, TArg2, TResult>
	{
		public IMethodMapper<TInterface, TContext> Use(Func<TContext, TArg1, TArg2, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class FunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TResult> : MethodBinder<TInterface, TContext>, IFunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TResult>
	{
		public IMethodMapper<TInterface, TContext> Use(Func<TContext, TArg1, TArg2, TArg3, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class FunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TResult> : MethodBinder<TInterface, TContext>, IFunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TResult>
	{
		public IMethodMapper<TInterface, TContext> Use(Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class FunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> : MethodBinder<TInterface, TContext>, IFunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
	{
		public IMethodMapper<TInterface, TContext> Use(Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}
}