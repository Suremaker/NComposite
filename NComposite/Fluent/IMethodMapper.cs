using System;
using System.Linq.Expressions;

namespace NComposite.Fluent
{
	public interface IMethodMapper<TInterface, out TContext>
	{
		IActionBinder<TInterface, TContext> For(Expression<Func<TInterface, Action>> interfaceMethod);
		IActionBinder<TInterface, TContext, TArg> For<TArg>(Expression<Func<TInterface, Action<TArg>>> interfaceMethod);
		IActionBinder<TInterface, TContext, TArg1, TArg2> For<TArg1, TArg2>(Expression<Func<TInterface, Action<TArg1, TArg2>>> interfaceMethod);
		IActionBinder<TInterface, TContext, TArg1, TArg2, TArg3> For<TArg1, TArg2, TArg3>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3>>> interfaceMethod);
		IActionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4> For<TArg1, TArg2, TArg3, TArg4>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3, TArg4>>> interfaceMethod);
		IActionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TArg5> For<TArg1, TArg2, TArg3, TArg4, TArg5>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3, TArg4, TArg5>>> interfaceMethod);

		IFunctionBinder<TInterface, TContext, TResult> For<TResult>(Expression<Func<TInterface, Func<TResult>>> interfaceMethod);
		IFunctionBinder<TInterface, TContext, TArg, TResult> For<TArg, TResult>(Expression<Func<TInterface, Func<TArg, TResult>>> interfaceMethod);
		IFunctionBinder<TInterface, TContext, TArg1, TArg2, TResult> For<TArg1, TArg2, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TResult>>> interfaceMethod);
		IFunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TResult> For<TArg1, TArg2, TArg3, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TResult>>> interfaceMethod);
		IFunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TResult> For<TArg1, TArg2, TArg3, TArg4, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TArg4, TResult>>> interfaceMethod);
		IFunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> For<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>>> interfaceMethod);
	}
}