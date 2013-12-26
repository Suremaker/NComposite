using System;
using NComposite.UnitTests.Interfaces;
using NComposite.UnitTests.Maps;
using NUnit.Framework;

namespace NComposite.UnitTests
{
	[TestFixture]
	public class SimpleMappingsTests
	{
		private CompositeFactory _factory;

		[SetUp]
		public void SetUp()
		{
			_factory = new CompositeFactory();
		}

		[Test]
		public void Should_map_simple_interface()
		{
			_factory.Load(new SimpleInterfaceMap());
			var simple = _factory.Create<ISimpleInterface>();
			simple.Foo();
			Assert.That(simple.Bar(), Is.EqualTo("text"));
			Assert.That(simple.Baz(5), Is.EqualTo("5"));
		}

		[Test]
		public void Should_not_allow_incomplete_method_mappings()
		{
			var exception = Assert.Throws<InvalidOperationException>(() => _factory.Load(new SimpleInterfaceMap(true)));
			var expectedMessage = string.Format("{0} mapping is incomplete:\nMissing mapping for: {1}\nMissing mapping for: {2}",
				typeof(ISimpleInterface).FullName,
				typeof(ISimpleInterface).GetMethod("Bar"),
				typeof(ISimpleInterface).GetMethod("Baz"));
			Console.WriteLine(exception.Message);
			Assert.That(exception.Message, Is.EqualTo(expectedMessage));
		}
	}
}
