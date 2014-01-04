using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using LambdaReflection.Generic;

namespace NComposite.Fluent.Properties.StateMapping
{
	public class StateMappings
	{
		public static Func<IContext<TInterface, TState>, TArg> GenerateGetter<TInterface, TState, TArg>(PropertyInfo stateProperty)
		{
			var lambda = GenerateGetterLambda<TInterface, TState, TArg>(stateProperty);

			var compiledMethod = CompileToStaticMethod(lambda, typeof(TInterface).Name+"StateAccessor", "Get"+stateProperty.Name);
			return (Func<IContext<TInterface, TState>, TArg>)Delegate.CreateDelegate(typeof(Func<IContext<TInterface, TState>, TArg>), compiledMethod);
		}

		public static Action<IContext<TInterface, TState>, TArg> GenerateSetter<TInterface, TState, TArg>(PropertyInfo stateProperty)
		{
			var lambda = GenerateSetterLambda<TInterface, TState, TArg>(stateProperty);

			var compiledMethod = CompileToStaticMethod(lambda, typeof(TInterface).Name + "StateAccessor", "Set" + stateProperty.Name);
			return (Action<IContext<TInterface, TState>, TArg>)Delegate.CreateDelegate(typeof(Action<IContext<TInterface, TState>, TArg>), compiledMethod);
		}

		private static LambdaExpression GenerateGetterLambda<TInterface, TState, TArg>(PropertyInfo stateProperty)
		{
			var ctxParam = Expression.Parameter(typeof(IContext<TInterface, TState>), "ctx");
			var stateGetter = Expression.Property(ctxParam, PropertyReflector<IContext<TInterface, TState>>.FromGetter(s => s.State));
			var statePropertyGetter = Expression.Property(stateGetter, stateProperty);
			return Expression.Lambda<Func<IContext<TInterface, TState>, TArg>>(statePropertyGetter, ctxParam);
		}

		private static LambdaExpression GenerateSetterLambda<TInterface, TState, TArg>(PropertyInfo stateProperty)
		{
			var setMethod = stateProperty.GetSetMethod();
			var ctxParam = Expression.Parameter(typeof (IContext<TInterface, TState>), "ctx");
			var argParam = Expression.Parameter(typeof (TArg), "value");
			var stateGetter = Expression.Property(ctxParam,PropertyReflector<IContext<TInterface, TState>>.FromGetter(s => s.State));
			var statePropertySetMethod = Expression.Call(stateGetter, setMethod, argParam);
			return Expression.Lambda<Action<IContext<TInterface, TState>, TArg>>(statePropertySetMethod, ctxParam, argParam);
		}

		private static MethodInfo CompileToStaticMethod(LambdaExpression lambda, string typeName, string methodName)
		{
			var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
			var moduleBuilder = assemblyBuilder.DefineDynamicModule("Module");
			var typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public | TypeAttributes.Class);
			var methodBuilder = typeBuilder.DefineMethod(methodName, MethodAttributes.Public | MethodAttributes.Static);
			lambda.CompileToMethod(methodBuilder);
			var accessorType = typeBuilder.CreateType();
			return accessorType.GetMethod(methodName);
		}
	}
}