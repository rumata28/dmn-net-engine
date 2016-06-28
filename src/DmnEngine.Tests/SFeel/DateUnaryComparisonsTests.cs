using System;

using NUnit.Framework;

namespace DmnEngine.Tests.SFeel
{
	[TestFixture]
	public class DateUnaryComparisonsTests : SfeelTester
	{
		[Test]
		public void Test_Literal_Date()
		{
			ExpectSfeel(@"date(""2015-05-06"")", new DateTime(2015, 5, 6), true);
		}

		[Test]
		public void Test_not_Literal_Date()
		{
			ExpectSfeel(@"not(date(""2015-05-06""))", new DateTime(2015, 5, 6), false);
			ExpectSfeel(@"not(date(""2015-05-06""))", new DateTime(2015, 5, 7), true);
		}

		[Test]
		public void Test_Literal_Date_list()
		{
			ExpectSfeel(@"date(""2015-05-06""), date(""2015-05-08"")", new DateTime(2015, 5, 5), false);
			ExpectSfeel(@"date(""2015-05-06""), date(""2015-05-08"")", new DateTime(2015, 5, 6), true);
			ExpectSfeel(@"date(""2015-05-06""), date(""2015-05-08"")", new DateTime(2015, 5, 7), false);
			ExpectSfeel(@"date(""2015-05-06""), date(""2015-05-08"")", new DateTime(2015, 5, 8), true);
			ExpectSfeel(@"date(""2015-05-06""), date(""2015-05-08"")", new DateTime(2015, 5, 9), false);
		}

		[Test]
		public void Test_Range_Close_Close()
		{
			ExpectSfeel(@"(date(""2015-05-05"")..date(""2015-05-09""))", new DateTime(2015, 5, 5), false);
			ExpectSfeel(@"(date(""2015-05-05"")..date(""2015-05-09""))", new DateTime(2015, 5, 6), true);
			ExpectSfeel(@"(date(""2015-05-05"")..date(""2015-05-09""))", new DateTime(2015, 5, 7), true);
			ExpectSfeel(@"(date(""2015-05-05"")..date(""2015-05-09""))", new DateTime(2015, 5, 8), true);
			ExpectSfeel(@"(date(""2015-05-05"")..date(""2015-05-09""))", new DateTime(2015, 5, 9), false);
		}
	}
}