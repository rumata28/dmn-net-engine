using System;

using NUnit.Framework;

namespace DmnEngine.Tests.SFeel
{
	[TestFixture]
	public class DaysAndHoursDurationUnaryComparisonsTests : SfeelTester
	{
		[Test]
		public void Test_Literal_Duration_Days()
		{
			ExpectSfeel(@"duration(""P1D"")", TimeSpan.FromDays(1), true);
		}

		[Test]
		public void Test_Literal_Duration_Hours()
		{
			ExpectSfeel(@"duration(""PT26H"")", TimeSpan.FromHours(26), true);
		}

		[Test]
		public void Test_Literal_Duration_DaysHours()
		{
			ExpectSfeel(@"duration(""P1DT26H"")", TimeSpan.FromHours(50), true);
		}

		[Test]
		public void Test_List()
		{
			ExpectSfeel(@"duration(""PT26H""), duration(""P1D""), duration(""PT20H"")", TimeSpan.FromHours(20), true);
			ExpectSfeel(@"duration(""PT26H""), duration(""P1D""), duration(""PT20H"")", TimeSpan.FromHours(21), false);
			ExpectSfeel(@"duration(""PT26H""), duration(""P1D""), duration(""PT20H"")", TimeSpan.FromHours(24), true);
			ExpectSfeel(@"duration(""PT26H""), duration(""P1D""), duration(""PT20H"")", TimeSpan.FromHours(25), false);
			ExpectSfeel(@"duration(""PT26H""), duration(""P1D""), duration(""PT20H"")", TimeSpan.FromHours(26), true);
		}

		[Test]
		public void Test_not_List()
		{
			ExpectSfeel(@"not(duration(""PT26H""), duration(""P1D""), duration(""PT20H""))", TimeSpan.FromHours(20), false);
			ExpectSfeel(@"not(duration(""PT26H""), duration(""P1D""), duration(""PT20H""))", TimeSpan.FromHours(21), true);
			ExpectSfeel(@"not(duration(""PT26H""), duration(""P1D""), duration(""PT20H""))", TimeSpan.FromHours(24), false);
			ExpectSfeel(@"not(duration(""PT26H""), duration(""P1D""), duration(""PT20H""))", TimeSpan.FromHours(25), true);
			ExpectSfeel(@"not(duration(""PT26H""), duration(""P1D""), duration(""PT20H""))", TimeSpan.FromHours(26), false);
		}

		[Test]
		public void Test_GreaterThan()
		{
			ExpectSfeel(@">duration(""PT26H"")", TimeSpan.FromHours(26), false);
			ExpectSfeel(@">duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(1)), true);
		}

		[Test]
		public void Test_LessThan()
		{
			ExpectSfeel(@"<duration(""PT26H"")", TimeSpan.FromHours(26), false);
			ExpectSfeel(@"<duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(-1)), true);
		}

		[Test]
		public void Test_GreaterThanOrEqual()
		{
			ExpectSfeel(@">=duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(-1)), false);
			ExpectSfeel(@">=duration(""PT26H"")", TimeSpan.FromHours(26), true);
			ExpectSfeel(@">=duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(1)), true);
		}

		[Test]
		public void Test_LessThanOrEqual()
		{
			ExpectSfeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(-1)), true);
			ExpectSfeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(26), true);
			ExpectSfeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(26).Add(TimeSpan.FromMilliseconds(1)), false);
		}

		[Test]
		public void Test_Range()
		{
			ExpectSfeel(@"[duration(""PT1H"")..duration(""PT2H"")]", TimeSpan.FromHours(1).Add(TimeSpan.FromMilliseconds(-1)), false);
			ExpectSfeel(@"[duration(""PT1H"")..duration(""PT2H"")]", TimeSpan.FromHours(1), true);
			ExpectSfeel(@"[duration(""PT1H"")..duration(""PT2H"")]", TimeSpan.FromHours(2), true);
			ExpectSfeel(@"[duration(""PT1H"")..duration(""PT2H"")]", TimeSpan.FromHours(2).Add(TimeSpan.FromMilliseconds(1)), false);
		}
	}
}