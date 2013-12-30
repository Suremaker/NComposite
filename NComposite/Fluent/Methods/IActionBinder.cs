using System;

namespace NComposite.Fluent.Methods
{
	public interface IActionBinder<TInterface, out TContext>
	{
		IMethodMapper<TInterface, TContext> Use(Action<TContext> methodImplementation);
	}

	public interface IActionBinder<TInterface, out TContext, out TArg>
	{
		IMethodMapper<TInterface, TContext> Use(Action<TContext, TArg> methodImplementation);
	}

	public interface IActionBinder<TInterface, out TContext, out TArg1, out TArg2>
	{
		IMethodMapper<TInterface, TContext> Use(Action<TContext, TArg1, TArg2> methodImplementation);
	}

	public interface IActionBinder<TInterface, out TContext, out TArg1, out TArg2, out TArg3>
	{
		IMethodMapper<TInterface, TContext> Use(Action<TContext, TArg1, TArg2, TArg3> methodImplementation);
	}

	public interface IActionBinder<TInterface, out TContext, out TArg1, out TArg2, out TArg3, out TArg4>
	{
		IMethodMapper<TInterface, TContext> Use(Action<TContext, TArg1, TArg2, TArg3, TArg4> methodImplementation);
	}

	public interface IActionBinder<TInterface, out TContext, out TArg1, out TArg2, out TArg3, out TArg4, out TArg5>
	{
		IMethodMapper<TInterface, TContext> Use(Action<TContext, TArg1, TArg2, TArg3, TArg4, TArg5> methodImplementation);
	}
}