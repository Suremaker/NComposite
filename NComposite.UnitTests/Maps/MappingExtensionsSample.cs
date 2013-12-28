using System.Globalization;
using NComposite.UnitTests.Interfaces;

namespace NComposite.UnitTests.Maps
{
	class MappingExtensionsSample : CompositeMap<IMappingExtensionsSample>
	{
		protected override void Map(ICompositeBuilder<IMappingExtensionsSample, INoState> builder)
		{
			builder.MapAction(m => m.For(x => x.Action0).Use(Action0Impl));
			builder.MapAction(m => m.For<string>(x => x.Action1).Use(Action1Impl));
			builder.MapAction(m => m.For<int, string>(x => x.Action2).Use(Action2Impl));
			builder.MapMethod(m => m.For<int>(x => x.Method0).Use(ctx => 2));
			builder.MapMethod(m => m.For<int, string>(x => x.Method1).Use(Method1Impl));
			builder.MapMethod(m => m.For<int, double, string>(x => x.Method2).Use(Method2Impl));
		}

		private static string Method2Impl(IContext<IMappingExtensionsSample, INoState> arg1, int arg2, double arg3)
		{
			return (arg2 * arg3).ToString(CultureInfo.InvariantCulture);
		}

		private static string Method1Impl(IContext<IMappingExtensionsSample, INoState> arg1, int arg2)
		{
			return arg2.ToString(CultureInfo.InvariantCulture);
		}

		private static void Action2Impl(IContext<IMappingExtensionsSample, INoState> arg1, int arg2, string arg3)
		{
		}

		private static void Action1Impl(IContext<IMappingExtensionsSample, INoState> arg1, string arg2)
		{
		}

		private static void Action0Impl(IContext<IMappingExtensionsSample, INoState> ctx)
		{
		}
	}
}