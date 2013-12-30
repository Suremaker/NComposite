namespace NComposite.UnitTests.Interfaces
{
	public interface IPropertyExtensionsSample
	{
		string Text { get; set; }
		int SetOnly { set; }
		int GetOnly { get; }

		string OtherText { get; set; }
		string AnotherText { get; set; }
	}
}