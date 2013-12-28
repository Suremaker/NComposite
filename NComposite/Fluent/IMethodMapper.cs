using System;
using System.Linq.Expressions;
using System.Reflection;
using NComposite.Helpers;

namespace NComposite.Fluent
{
	public interface IMethodMapper<TInterface, out TContext>
	{
		IFuncBinder<TContext, TResult> For<TResult>(Expression<Func<TInterface, Func<TResult>>> interfaceMethod);
		IFuncBinder<TContext, TArg, TResult> For<TArg, TResult>(Expression<Func<TInterface, Func<TArg, TResult>>> interfaceMethod);
		IFuncBinder<TContext, TArg1, TArg2, TResult> For<TArg1, TArg2, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TResult>>> interfaceMethod);
		IFuncBinder<TContext, TArg1, TArg2, TArg3, TResult> For<TArg1, TArg2, TArg3, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TResult>>> interfaceMethod);
		IFuncBinder<TContext, TArg1, TArg2, TArg3, TArg4, TResult> For<TArg1, TArg2, TArg3, TArg4, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TArg4, TResult>>> interfaceMethod);
		IFuncBinder<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> For<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>>> interfaceMethod);
	}

	public interface IFuncBinder<out TContext, in TResult>
	{
		Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TResult> methodImplementation);
	}

	public interface IFuncBinder<out TContext, out TArg, in TResult>
	{
		Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TArg, TResult> methodImplementation);
	}

	public interface IFuncBinder<out TContext, out TArg1, out TArg2, in TResult>
	{
		Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TArg1, TArg2, TResult> methodImplementation);
	}

	public interface IFuncBinder<out TContext, out TArg1, out TArg2, out TArg3, in TResult>
	{
		Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TArg1, TArg2, TArg3, TResult> methodImplementation);
	}

	public interface IFuncBinder<out TContext, out TArg1, out TArg2, out TArg3, out TArg4, in TResult>
	{
		Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult> methodImplementation);
	}

	public interface IFuncBinder<out TContext, out TArg1, out TArg2, out TArg3, out TArg4, out TArg5, in TResult>
	{
		Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> methodImplementation);
	}

	class MethodMapper<TInterface, TContext> : IMethodMapper<TInterface, TContext>
	{
		public IFuncBinder<TContext, TResult> For<TResult>(Expression<Func<TInterface, Func<TResult>>> interfaceMethod)
		{
			return new FuncBinder<TContext, TResult> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		public IFuncBinder<TContext, TArg, TResult> For<TArg, TResult>(Expression<Func<TInterface, Func<TArg, TResult>>> interfaceMethod)
		{
			return new FuncBinder<TContext, TArg, TResult> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		public IFuncBinder<TContext, TArg1, TArg2, TResult> For<TArg1, TArg2, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TResult>>> interfaceMethod)
		{
			return new FuncBinder<TContext, TArg1, TArg2, TResult> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		public IFuncBinder<TContext, TArg1, TArg2, TArg3, TResult> For<TArg1, TArg2, TArg3, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TResult>>> interfaceMethod)
		{
			return new FuncBinder<TContext, TArg1, TArg2, TArg3, TResult> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		public IFuncBinder<TContext, TArg1, TArg2, TArg3, TArg4, TResult> For<TArg1, TArg2, TArg3, TArg4, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TArg4, TResult>>> interfaceMethod)
		{
			return new FuncBinder<TContext, TArg1, TArg2, TArg3, TArg4, TResult> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		public IFuncBinder<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> For<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Expression<Func<TInterface, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>>> interfaceMethod)
		{
			return new FuncBinder<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		private MethodInfo GetMethod(LambdaExpression expression)
		{
			return expression.DelegateResultToMethodInfo();
		}
	}

	internal class FuncBinder<TContext, TResult> : MethodBinder, IFuncBinder<TContext, TResult>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class FuncBinder<TContext, TArg, TResult> : MethodBinder, IFuncBinder<TContext, TArg, TResult>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TArg, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class FuncBinder<TContext, TArg1, TArg2, TResult> : MethodBinder, IFuncBinder<TContext, TArg1, TArg2, TResult>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TArg1, TArg2, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class FuncBinder<TContext, TArg1, TArg2, TArg3, TResult> : MethodBinder, IFuncBinder<TContext, TArg1, TArg2, TArg3, TResult>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TArg1, TArg2, TArg3, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class FuncBinder<TContext, TArg1, TArg2, TArg3, TArg4, TResult> : MethodBinder, IFuncBinder<TContext, TArg1, TArg2, TArg3, TArg4, TResult>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class FuncBinder<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> : MethodBinder, IFuncBinder<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}
}