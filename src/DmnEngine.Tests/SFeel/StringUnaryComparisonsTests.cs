using NUnit.Framework;

namespace DmnEngine.Tests.SFeel
{
	[TestFixture]
	public class StringUnaryComparisonsTests : SfeelTester
	{
		[Test]
		public void Test_String()
		{
			ExpectSfeel(@"""a string""", "a string", true);
		}

		[Test]
		public void Test_not()
		{
			ExpectSfeel(@"not(""a string"")", "a string", false);
		}

		[Test]
		public void Test_List()
		{
			ExpectSfeel(@"""a string"", ""string2""", "string2", true);
		}

		[TestCase("string2", false)]
		[TestCase("string3", true)]
		public void Test_not_List(string value, bool expectation)
		{
			ExpectSfeel(@"not(""a string"", ""string2"")", value, expectation);
		}

		[TestCase(@">""a string""")]
		[TestCase(@">=""a string""")]
		[TestCase(@"<""a string""")]
		[TestCase(@"<=""a string""")]
		public void Test_CannotCompare(string sfeel)
		{
			Expect(() => SFeelEval(sfeel, "a string"), Throws.Exception);
		}
	}
}