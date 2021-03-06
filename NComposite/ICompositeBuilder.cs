﻿using System.Reflection;

namespace NComposite
{
	public interface IContext { }
	public interface IContext<TInterface, TState> : IContext
	{
		TState State { get; }
	}

	internal class Context<TInterface, TState> : IContext<TInterface, TState>
	{
		public Context(TState state)
		{
			State = state;
		}

		public TState State { get; private set; }
	}

	public interface ICompositeBuilder
	{
		void MapMethod(MethodInfo interfaceMethod, MethodInfo methodImplementation);
	}

	public interface ICompositeBuilder<TInterface, TState> : ICompositeBuilder
	{
	}
}