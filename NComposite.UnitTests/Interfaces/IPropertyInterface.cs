namespace NComposite.UnitTests.Interfaces
{
	public interface IPropertyInterface
	{
		string Text { get; set; }
		int SetOnly { set; }
		int GetOnly { get; }
	}
}