using System;

using NUnit.Framework;

using Softengi.DmnEngine.SFeel.Evaluation;

namespace DmnEngine.Tests.SFeel
{
	[TestFixture]
	public class MonthsAndYearsDurationUnaryComparisonsTests : SfeelTester
	{
		// TODO:

		[Test]
		public void Test_GreaterThan()
		{
			ExpectSfeel(@">duration(""P1Y"")", EvaluationValue.Years(1), false);
			ExpectSfeel(@">duration(""P1Y"")", EvaluationValue.Years(1, 1), true);
		}

		[Test]
		public void Test_GreaterThanOrEqual()
		{
			ExpectSfeel(@">=duration(""P1Y"")", EvaluationValue.Months(11), false);
			ExpectSfeel(@">=duration(""P1Y"")", EvaluationValue.Years(1), true);
		}

		[Test]
		public void Test_LessThan()
		{
			ExpectSfeel(@"<duration(""PT26H"")", TimeSpan.FromHours(26), false);
			ExpectSfeel(@"<duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(-1)), true);
		}

		[Test]
		public void Test_LessThanOrEqual()
		{
			ExpectSfeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(-1)), true);
			ExpectSfeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(26), true);
			ExpectSfeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(1)), false);
		}

		[TestCase(20, true)]
		[TestCase(21, false)]
		[TestCase(24, true)]
		[TestCase(25, false)]
		[TestCase(26, true)]
		public void Test_List(int hours, bool expectEqual)
		{
			ExpectSfeel(@"duration(""PT26H""), duration(""P1D""), duration(""PT20H"")", TimeSpan.FromHours(hours), expectEqual);
		}
	}
}