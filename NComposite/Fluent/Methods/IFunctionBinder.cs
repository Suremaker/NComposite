using System;

namespace NComposite.Fluent.Methods
{
	public interface IFunctionBinder<TInterface, out TContext, in TResult>
	{
		IMethodMapper<TInterface, TContext> Use(Func<TContext, TResult> methodImplementation);
	}

	public interface IFunctionBinder<TInterface, out TContext, out TArg, in TResult>
	{
		IMethodMapper<TInterface, TContext> Use(Func<TContext, TArg, TResult> methodImplementation);
	}

	public interface IFunctionBinder<TInterface, out TContext, out TArg1, out TArg2, in TResult>
	{
		IMethodMapper<TInterface, TContext> Use(Func<TContext, TArg1, TArg2, TResult> methodImplementation);
	}

	public interface IFunctionBinder<TInterface, out TContext, out TArg1, out TArg2, out TArg3, in TResult>
	{
		IMethodMapper<TInterface, TContext> Use(Func<TContext, TArg1, TArg2, TArg3, TResult> methodImplementation);
	}

	public interface IFunctionBinder<TInterface, out TContext, out TArg1, out TArg2, out TArg3, out TArg4, in TResult>
	{
		IMethodMapper<TInterface, TContext> Use(Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult> methodImplementation);
	}

	public interface IFunctionBinder<TInterface, out TContext, out TArg1, out TArg2, out TArg3, out TArg4, out TArg5, in TResult>
	{
		IMethodMapper<TInterface, TContext> Use(Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> methodImplementation);
	}
}