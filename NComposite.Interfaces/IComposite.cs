using System;

namespace NComposite.Interfaces
{
	public interface IComposite
	{
		TypeMapping Mapping { get; }
		TypeMapping[] Extensions { get; }
		Type[] InheritedTypes { get; }
	}
}