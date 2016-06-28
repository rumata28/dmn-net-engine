using NUnit.Framework;

namespace DmnEngine.Tests.SFeel
{
	[TestFixture]
	public class BooleanUnaryComparisonsTests : SfeelTester
	{
		[TestCase("true", true)]
		[TestCase("false", false)]
		public void Test_Literal(string sfeelExpression, bool expectedValue)
		{
			ExpectSfeel(sfeelExpression, expectedValue, true);
		}

		[TestCase(">true")]
		[TestCase(">=true")]
		[TestCase("<true")]
		[TestCase("<=true")]
		public void Test_CannotCompare(string sfeelExpressionToFail)
		{
			Expect(() => SFeelEval(sfeelExpressionToFail, true), Throws.Exception);
		}
	}
}