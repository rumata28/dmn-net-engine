using NUnit.Framework;

namespace Softengi.DmnEngine.Tests.Feel
{
	[TestFixture]
	public class StringUnaryComparisonsTests : FeelTester
	{
		[Test]
		public void Test_String()
		{
			ExpectFeel(@"""a string""", "a string", true);
		}

		[Test]
		public void Test_not()
		{
			ExpectFeel(@"not(""a string"")", "a string", false);
		}

		[Test]
		public void Test_List()
		{
			ExpectFeel(@"""a string"", ""string2""", "string2", true);
		}

		[TestCase("string2", false)]
		[TestCase("string3", true)]
		public void Test_not_List(string value, bool expectation)
		{
			ExpectFeel(@"not(""a string"", ""string2"")", value, expectation);
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