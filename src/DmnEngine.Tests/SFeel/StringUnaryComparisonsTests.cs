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

		[Test]
		public void Test_not_List()
		{
			ExpectSfeel(@"not(""a string"", ""string2"")", "string2", false);
			ExpectSfeel(@"not(""a string"", ""string2"")", "string3", true);
		}

		[Test]
		public void Test_CannotCompare()
		{
			Expect(() => SFeelEval(@">""a string""", "a string"), Throws.Exception);
			Expect(() => SFeelEval(@">=""a string""", "a string"), Throws.Exception);
			Expect(() => SFeelEval(@"<""a string""", "a string"), Throws.Exception);
			Expect(() => SFeelEval(@"<=""a string""", "a string"), Throws.Exception);
		}
	}
}