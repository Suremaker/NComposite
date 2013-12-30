using NComposite.UnitTests.Interfaces;

namespace NComposite.UnitTests.Maps
{
	public interface IPropertyExtensionsState
	{
		string TextState { get; set; }
		int Value { get; set; }
		string AnotherTextState { get; set; }
		string OtherText { get; set; }
	}

	class PropertyExtensionsSampleMap : CompositeMap<IPropertyExtensionsSample, IPropertyExtensionsState>
	{
		protected override void Map(ICompositeBuilder<IPropertyExtensionsSample, IPropertyExtensionsState> builder)
		{
			builder.MapProperties()
				.For(x => x.Text).UseStateProperty(s => s.TextState)

				.ForGetter(x => x.GetOnly).UseStateProperty(s => s.Value)
				.ForSetter<int>((x, v) => x.SetOnly = v).UseStateProperty(s => s.Value)

				.ForGetter(x => x.OtherText).Use(GetOtherTextImpl)
				.ForSetter<string>((x, v) => x.OtherText = v).Use(SetOtherTextImpl)

				.ForGetter(x => x.AnotherText).Use(ctx => ctx.State.AnotherTextState)
				.ForSetter<string>((x, v) => x.AnotherText = v).Use((ctx, value) => ctx.State.AnotherTextState = value);
		}

		private static void SetOtherTextImpl(IContext<IPropertyExtensionsSample, IPropertyExtensionsState> ctx, string value)
		{
			ctx.State.OtherText = value;
		}

		private static string GetOtherTextImpl(IContext<IPropertyExtensionsSample, IPropertyExtensionsState> ctx)
		{
			return ctx.State.OtherText;
		}
	}
}