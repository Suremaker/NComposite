using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NComposite.Interfaces
{
	public class TypeMapping
	{
		public TypeMapping(Type interfaceType, Type stateType, IEnumerable<KeyValuePair<MethodInfo, MethodInfo>> methodBindings)
		{
			MethodBindings = methodBindings.ToArray();
			State = stateType;
			Interface = interfaceType;
		}

		public Type Interface { get; private set; }
		public Type State { get; private set; }
		public KeyValuePair<MethodInfo, MethodInfo>[] MethodBindings { get; private set; }
	}
}