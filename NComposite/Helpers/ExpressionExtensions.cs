using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NComposite.Helpers
{
	public static class ExpressionExtensions
	{
		public static MethodInfo DelegateResultToMethodInfo(this LambdaExpression expression)
		{
			try
			{
				var convertExpression = (UnaryExpression)expression.Body;
				var createDelegateExpression = (MethodCallExpression)convertExpression.Operand;
				var methodInfoArgument = (ConstantExpression)createDelegateExpression.Arguments[2];
				return (MethodInfo)methodInfoArgument.Value;
			}
			catch (Exception e)
			{
				throw new ArgumentException("Given lambda expression is not in format 'x => x.MethodName': " + expression, e);
			}
		}

		public static MethodInfo MethodCallToMethodInfo(this LambdaExpression expression)
		{
			return ((MethodCallExpression)expression.Body).Method;
		}
	}
}
