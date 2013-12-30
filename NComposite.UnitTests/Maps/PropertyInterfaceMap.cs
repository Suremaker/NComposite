using NComposite.UnitTests.Interfaces;

namespace NComposite.UnitTests.Maps
{
	public interface IPropertyState
	{
		string Text { get; set; }
		int Value { get; set; }
	}

	class PropertyInterfaceMap : CompositeMap<IPropertyInterface, IPropertyState>
	{
		protected override void Map(ICompositeBuilder<IPropertyInterface, IPropertyState> builder)
		{
			builder.MapMethod(typeof(IPropertyInterface).GetProperty("Text").GetGetMethod(), GetType().GetMethod("GetTextImpl"));
			builder.MapMethod(typeof(IPropertyInterface).GetProperty("Text").GetSetMethod(), GetType().GetMethod("SetTextImpl"));
			builder.MapMethod(typeof(IPropertyInterface).GetProperty("SetOnly").GetSetMethod(), GetType().GetMethod("SetOnlyImpl"));
			builder.MapMethod(typeof(IPropertyInterface).GetProperty("GetOnly").GetGetMethod(), GetType().GetMethod("GetOnlyImpl"));
		}

		public static string GetTextImpl(IContext<IPropertyInterface, IPropertyState> ctx)
		{
			return ctx.State.Text;
		}

		public static void SetTextImpl(IContext<IPropertyInterface, IPropertyState> ctx, string text)
		{
			ctx.State.Text = text;
		}

		public static int GetOnlyImpl(IContext<IPropertyInterface, IPropertyState> ctx)
		{
			return ctx.State.Value;
		}

		public static void SetOnlyImpl(IContext<IPropertyInterface, IPropertyState> ctx, int value)
		{
			ctx.State.Value = value;
		}
	}
}