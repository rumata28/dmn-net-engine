using System;

using NUnit.Framework;

using Softengi.DmnEngine.Evaluation;

namespace Softengi.DmnEngine.Tests.Feel
{
	[TestFixture]
	public class MonthsAndYearsDurationUnaryComparisonsTests : FeelTester
	{
		// TODO:

		[Test]
		public void Test_GreaterThan()
		{
			ExpectFeel(@">duration(""P1Y"")", EvaluationValue.Years(1), false);
			ExpectFeel(@">duration(""P1Y"")", EvaluationValue.Years(1, 1), true);
		}

		[Test]
		public void Test_GreaterThanOrEqual()
		{
			ExpectFeel(@">=duration(""P1Y"")", EvaluationValue.Months(11), false);
			ExpectFeel(@">=duration(""P1Y"")", EvaluationValue.Years(1), true);
		}

		[Test]
		public void Test_LessThan()
		{
			ExpectFeel(@"<duration(""PT26H"")", TimeSpan.FromHours(26), false);
			ExpectFeel(@"<duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(-1)), true);
		}

		[Test]
		public void Test_LessThanOrEqual()
		{
			ExpectFeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(-1)), true);
			ExpectFeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(26), true);
			ExpectFeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(1)), false);
		}

		[TestCase(20, true)]
		[TestCase(21, false)]
		[TestCase(24, true)]
		[TestCase(25, false)]
		[TestCase(26, true)]
		public void Test_List(int hours, bool expectEqual)
		{
			ExpectFeel(@"duration(""PT26H""), duration(""P1D""), duration(""PT20H"")", TimeSpan.FromHours(hours), expectEqual);
		}
	}
}