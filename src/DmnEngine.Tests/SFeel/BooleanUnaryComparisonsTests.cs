using NUnit.Framework;

namespace DmnEngine.Tests.SFeel
{
	[TestFixture]
	public class BooleanUnaryComparisonsTests : SfeelTester
	{
		[Test]
		public void Test_Literal()
		{
			ExpectSfeel("true", true, true);
			ExpectSfeel("false", false, true);
		}

		[Test]
		public void Test_CannotCompare()
		{
			Expect(() => SFeelEval(">true", true), Throws.Exception);
			Expect(() => SFeelEval("<true", true), Throws.Exception);
			Expect(() => SFeelEval(">=true", true), Throws.Exception);
			Expect(() => SFeelEval("<=true", true), Throws.Exception);
		}
	}
}