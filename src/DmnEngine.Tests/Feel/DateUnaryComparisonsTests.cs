using System;

using NUnit.Framework;

namespace Softengi.DmnEngine.Tests.Feel
{
	[TestFixture]
	public class DateUnaryComparisonsTests : FeelTester
	{
		[Test]
		public void Test_Literal_Date()
		{
			ExpectFeel(@"date(""2015-05-06"")", new DateTime(2015, 5, 6), true);
		}

		[TestCase(2015, 5, 6, false)]
		[TestCase(2015, 5, 7, true)]
		public void Test_not_Literal_Date(int year, int month, int day, bool expected)
		{
			ExpectFeel(@"not(date(""2015-05-06""))", new DateTime(year, month, day), expected);
		}

		[TestCase(2015, 5, 5, false)]
		[TestCase(2015, 5, 6, true)]
		[TestCase(2015, 5, 7, false)]
		[TestCase(2015, 5, 8, true)]
		[TestCase(2015, 5, 9, false)]
		public void Test_Literal_Date_list(int year, int month, int day, bool expected)
		{
			ExpectFeel(@"date(""2015-05-06""), date(""2015-05-08"")", new DateTime(year, month, day), expected);
		}

		[TestCase(2015, 5, 5, false)]
		[TestCase(2015, 5, 6, true)]
		[TestCase(2015, 5, 7, true)]
		[TestCase(2015, 5, 8, true)]
		[TestCase(2015, 5, 9, false)]
		public void Test_Range_Close_Close(int year, int month, int day, bool expected)
		{
			ExpectFeel(@"(date(""2015-05-05"")..date(""2015-05-09""))", new DateTime(year, month, day), expected);
		}
	}
}