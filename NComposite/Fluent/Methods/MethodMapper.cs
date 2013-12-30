using System;
using System.Linq.Expressions;
using System.Reflection;
using NComposite.Helpers;

namespace NComposite.Fluent.Methods
{
	class MethodMapper<TInterface, TContext> : IMethodMapper<TInterface, TContext>
	{
		private readonly ICompositeBuilder _compositeBuilder;

		public MethodMapper(ICompositeBuilder compositeBuilder)
		{
			_compositeBuilder = compositeBuilder;
		}

		public IActionBinder<TInterface, TContext> For(Expression<Func<TInterface, Action>> interfaceMethod)
		{
			return new ActionBinder<TInterface, TContext> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IActionBinder<TInterface, TContext, TArg> For<TArg>(Expression<Func<TInterface, Action<TArg>>> interfaceMethod)
		{
			return new ActionBinder<TInterface, TContext, TArg> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IActionBinder<TInterface, TContext, TArg1, TArg2> For<TArg1, TArg2>(Expression<Func<TInterface, Action<TArg1, TArg2>>> interfaceMethod)
		{
			return new ActionBinder<TInterface, TContext, TArg1, TArg2> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IActionBinder<TInterface, TContext, TArg1, TArg2, TArg3> For<TArg1, TArg2, TArg3>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3>>> interfaceMethod)
		{
			return new ActionBinder<TInterface, TContext, TArg1, TArg2, TArg3> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IActionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4> For<TArg1, TArg2, TArg3, TArg4>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3, TArg4>>> interfaceMethod)
		{
			return new ActionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IActionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TArg5> For<TArg1, TArg2, TArg3, TArg4, TArg5>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3, TArg4, TArg5>>> interfaceMethod)
		{
			return new ActionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TArg5> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IFunctionBinder<TInterface, TContext, TResult> For<TResult>(Expression<Func<TInterface, Func<TResult>>> interfaceMethod)
		{
			return new FunctionBinder<TInterface, TContext, TResult> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IFunctionBinder<TInterface, TContext, TArg, TResult> For<TArg, TResult>(Expression<Func<TInterface, Func<TArg, TResult>>> interfaceMethod)
		{
			return new FunctionBinder<TInterface, TContext, TArg, TResult> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IFunctionBinder<TInterface, TContext, TArg1, TArg2, TResult> For<TArg1, TArg2, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TResult>>> interfaceMethod)
		{
			return new FunctionBinder<TInterface, TContext, TArg1, TArg2, TResult> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IFunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TResult> For<TArg1, TArg2, TArg3, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TResult>>> interfaceMethod)
		{
			return new FunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TResult> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IFunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TResult> For<TArg1, TArg2, TArg3, TArg4, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TArg4, TResult>>> interfaceMethod)
		{
			return new FunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TResult> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		public IFunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> For<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>>> interfaceMethod)
		{
			return new FunctionBinder<TInterface, TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> { InterfaceMethod = GetMethod(interfaceMethod), MethodMapper = this };
		}

		internal IMethodMapper<TInterface, TContext> Map(MethodInfo interfaceMethod, MethodInfo implementationMethod)
		{
			_compositeBuilder.MapMethod(interfaceMethod, implementationMethod);
			return this;
		}

		private MethodInfo GetMethod(LambdaExpression expression)
		{
			return expression.DelegateResultToMethodInfo();
		}
	}
}