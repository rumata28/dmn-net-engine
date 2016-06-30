using NUnit.Framework;

namespace Softengi.DmnEngine.Tests.Feel
{
	[TestFixture]
	public class BooleanUnaryComparisonsTests : FeelTester
	{
		[TestCase("true", true)]
		[TestCase("false", false)]
		public void Test_Literal(string sfeelExpression, bool expectedValue)
		{
			ExpectFeel(sfeelExpression, expectedValue, true);
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