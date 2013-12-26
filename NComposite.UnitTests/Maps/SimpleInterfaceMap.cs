using System.Globalization;
using NComposite.UnitTests.Interfaces;

namespace NComposite.UnitTests.Maps
{
	class SimpleInterfaceMap : CompositeMap<ISimpleInterface>
	{
		private readonly bool _incomplete;
		public SimpleInterfaceMap() : this(false) { }

		public SimpleInterfaceMap(bool incompleteMapping)
		{
			_incomplete = incompleteMapping;
		}

		protected override void Map(ICompositeBuilder<ISimpleInterface, INoState> builder)
		{
			builder.MapMethod(typeof(ISimpleInterface).GetMethod("Foo"), GetType().GetMethod("FooImpl"));

			if (!_incomplete)
			{
				builder.MapMethod(typeof(ISimpleInterface).GetMethod("Bar"), GetType().GetMethod("BarImpl"));
				builder.MapMethod(typeof(ISimpleInterface).GetMethod("Baz"), GetType().GetMethod("BazImpl"));
			}
		}

		public static void FooImpl(IContext<ISimpleInterface, INoState> ctx)
		{
		}

		public static string BarImpl(IContext<ISimpleInterface, INoState> ctx)
		{
			return "text";
		}

		public static string BazImpl(IContext<ISimpleInterface, INoState> ctx, int number)
		{
			return number.ToString(CultureInfo.InvariantCulture);
		}
	}
}
