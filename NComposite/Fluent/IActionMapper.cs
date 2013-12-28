using System;
using System.Linq.Expressions;
using System.Reflection;
using NComposite.Helpers;

namespace NComposite.Fluent
{
	public interface IActionMapper<TInterface, out TContext>
	{
		IActionBinder<TContext> For(Expression<Func<TInterface, Action>> interfaceMethod);
		IActionBinder<TContext, TArg> For<TArg>(Expression<Func<TInterface, Action<TArg>>> interfaceMethod);
		IActionBinder<TContext, TArg1, TArg2> For<TArg1, TArg2>(Expression<Func<TInterface, Action<TArg1, TArg2>>> interfaceMethod);
		IActionBinder<TContext, TArg1, TArg2, TArg3> For<TArg1, TArg2, TArg3>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3>>> interfaceMethod);
		IActionBinder<TContext, TArg1, TArg2, TArg3, TArg4> For<TArg1, TArg2, TArg3, TArg4>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3, TArg4>>> interfaceMethod);
		IActionBinder<TContext, TArg1, TArg2, TArg3, TArg4, TArg5> For<TArg1, TArg2, TArg3, TArg4, TArg5>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3, TArg4, TArg5>>> interfaceMethod);
	}

	public interface IActionBinder<out TContext>
	{
		Tuple<MethodInfo, MethodInfo> Use(Action<TContext> methodImplementation);
	}

	public interface IActionBinder<out TContext, out TArg>
	{
		Tuple<MethodInfo, MethodInfo> Use(Action<TContext, TArg> methodImplementation);
	}

	public interface IActionBinder<out TContext, out TArg1, out TArg2>
	{
		Tuple<MethodInfo, MethodInfo> Use(Action<TContext, TArg1, TArg2> methodImplementation);
	}

	public interface IActionBinder<out TContext, out TArg1, out TArg2, out TArg3>
	{
		Tuple<MethodInfo, MethodInfo> Use(Action<TContext, TArg1, TArg2, TArg3> methodImplementation);
	}

	public interface IActionBinder<out TContext, out TArg1, out TArg2, out TArg3, out TArg4>
	{
		Tuple<MethodInfo, MethodInfo> Use(Action<TContext, TArg1, TArg2, TArg3, TArg4> methodImplementation);
	}

	public interface IActionBinder<out TContext, out TArg1, out TArg2, out TArg3, out TArg4, out TArg5>
	{
		Tuple<MethodInfo, MethodInfo> Use(Action<TContext, TArg1, TArg2, TArg3, TArg4, TArg5> methodImplementation);
	}

	class ActionMapper<TInterface, TContext> : IActionMapper<TInterface, TContext>
	{
		public IActionBinder<TContext> For(Expression<Func<TInterface, Action>> interfaceMethod)
		{
			return new ActionBinder<TContext> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		public IActionBinder<TContext, TArg> For<TArg>(Expression<Func<TInterface, Action<TArg>>> interfaceMethod)
		{
			return new ActionBinder<TContext, TArg> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		public IActionBinder<TContext, TArg1, TArg2> For<TArg1, TArg2>(Expression<Func<TInterface, Action<TArg1, TArg2>>> interfaceMethod)
		{
			return new ActionBinder<TContext, TArg1, TArg2> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		public IActionBinder<TContext, TArg1, TArg2, TArg3> For<TArg1, TArg2, TArg3>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3>>> interfaceMethod)
		{
			return new ActionBinder<TContext, TArg1, TArg2, TArg3> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		public IActionBinder<TContext, TArg1, TArg2, TArg3, TArg4> For<TArg1, TArg2, TArg3, TArg4>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3, TArg4>>> interfaceMethod)
		{
			return new ActionBinder<TContext, TArg1, TArg2, TArg3, TArg4> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		public IActionBinder<TContext, TArg1, TArg2, TArg3, TArg4, TArg5> For<TArg1, TArg2, TArg3, TArg4, TArg5>(Expression<Func<TInterface, Action<TArg1, TArg2, TArg3, TArg4, TArg5>>> interfaceMethod)
		{
			return new ActionBinder<TContext, TArg1, TArg2, TArg3, TArg4, TArg5> { InterfaceMethod = GetMethod(interfaceMethod) };
		}

		private MethodInfo GetMethod(LambdaExpression expression)
		{
			return expression.DelegateResultToMethodInfo();
		}
	}

	internal class ActionBinder<TContext> : MethodBinder, IActionBinder<TContext>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Action<TContext> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class ActionBinder<TContext, TArg> : MethodBinder, IActionBinder<TContext, TArg>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Action<TContext, TArg> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class ActionBinder<TContext, TArg1, TArg2> : MethodBinder, IActionBinder<TContext, TArg1, TArg2>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Action<TContext, TArg1, TArg2> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class ActionBinder<TContext, TArg1, TArg2, TArg3> : MethodBinder, IActionBinder<TContext, TArg1, TArg2, TArg3>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Action<TContext, TArg1, TArg2, TArg3> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class ActionBinder<TContext, TArg1, TArg2, TArg3, TArg4> : MethodBinder, IActionBinder<TContext, TArg1, TArg2, TArg3, TArg4>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Action<TContext, TArg1, TArg2, TArg3, TArg4> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}

	internal class ActionBinder<TContext, TArg1, TArg2, TArg3, TArg4, TArg5> : MethodBinder, IActionBinder<TContext, TArg1, TArg2, TArg3, TArg4, TArg5>
	{
		public Tuple<MethodInfo, MethodInfo> Use(Action<TContext, TArg1, TArg2, TArg3, TArg4, TArg5> methodImplementation)
		{
			return Bind(methodImplementation.Method);
		}
	}
}