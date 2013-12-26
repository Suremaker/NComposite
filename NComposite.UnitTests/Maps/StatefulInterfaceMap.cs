using NComposite.UnitTests.Interfaces;

namespace NComposite.UnitTests.Maps
{
	public interface IState
	{
		string Text { get; set; }
	}

	class StatefulInterfaceMap : CompositeMap<IStatefulInterface, IState>
	{
		protected override void Map(ICompositeBuilder<IStatefulInterface, IState> builder)
		{
			builder.MapMethod(typeof(IStatefulInterface).GetMethod("SetText"), GetType().GetMethod("SetTextImpl"));
			builder.MapMethod(typeof(IStatefulInterface).GetMethod("GetText"), GetType().GetMethod("GetTextImpl"));
		}

		public static void SetTextImpl(IContext<IStatefulInterface, IState> ctx, string text)
		{
			ctx.State.Text = text;
		}

		public static string GetTextImpl(IContext<IStatefulInterface, IState> ctx)
		{
			return ctx.State.Text;
		}
	}
}