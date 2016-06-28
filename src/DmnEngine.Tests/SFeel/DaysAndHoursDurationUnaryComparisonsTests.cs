using System;

using NUnit.Framework;

namespace DmnEngine.Tests.SFeel
{
	[TestFixture]
	public class DaysAndHoursDurationUnaryComparisonsTests : SfeelTester
	{
		[TestCase(26, 0, false)]
		[TestCase(26, 1, true)]
		public void Test_GreaterThan(int hours, int ms, bool expected)
		{
			ExpectSfeel(@">duration(""PT26H"")", TimeSpan.FromHours(hours).Add(TimeSpan.FromMilliseconds(ms)), expected);
		}

		[TestCase(26, -1, false)]
		[TestCase(26, 0, true)]
		[TestCase(26, 1, true)]
		public void Test_GreaterThanOrEqual(int hours, int ms, bool expected)
		{
			ExpectSfeel(@">=duration(""PT26H"")", TimeSpan.FromHours(hours).Add(TimeSpan.FromMilliseconds(ms)), expected);
		}

		[TestCase(26, -1, true)]
		[TestCase(26, 0, false)]
		public void Test_LessThan(int hours, int ms, bool expected)
		{
			ExpectSfeel(@"<duration(""PT26H"")", TimeSpan.FromHours(hours).Add(TimeSpan.FromMilliseconds(ms)), expected);
		}

		[TestCase(26, -1, true)]
		[TestCase(26, 0, true)]
		[TestCase(26, 1, false)]
		public void Test_LessThanOrEqual(int hours, int ms, bool expected)
		{
			ExpectSfeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(hours).Add(TimeSpan.FromMilliseconds(ms)), expected);
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

		[Test]
		public void Test_Literal_Days()
		{
			ExpectSfeel(@"duration(""P1D"")", TimeSpan.FromDays(1), true);
		}

		[Test]
		public void Test_Literal_Days_negative()
		{
			ExpectSfeel(@"duration(""-P1D"")", TimeSpan.FromDays(-1), true);
		}

		[Test]
		public void Test_Literal_DaysHours()
		{
			ExpectSfeel(@"duration(""P1DT26H"")", TimeSpan.FromHours(50), true);
		}

		[Test]
		public void Test_Literal_DaysHours_negative()
		{
			ExpectSfeel(@"duration(""-P1DT26H"")", TimeSpan.FromHours(-50), true);
		}

		[Test]
		public void Test_Literal_DaysHoursMinutesSeconds()
		{
			ExpectSfeel(
				@"duration(""P1DT26H15M10S"")",
				TimeSpan
					.FromHours(50)
					.Add(TimeSpan.FromMinutes(15))
					.Add(TimeSpan.FromSeconds(10)),
				true);
		}

		[Test]
		public void Test_Literal_DaysHoursSeconds_negative()
		{
			ExpectSfeel(
				@"duration(""-P1DT26H15M10S"")",
				TimeSpan
					.FromHours(-50)
					.Add(TimeSpan.FromMinutes(-15))
					.Add(TimeSpan.FromSeconds(-10)),
				true);
		}

		[Test]
		public void Test_Literal_Hours()
		{
			ExpectSfeel(@"duration(""PT26H"")", TimeSpan.FromHours(26), true);
		}

		[Test]
		public void Test_Literal_Hours_negative()
		{
			ExpectSfeel(@"duration(""-PT26H"")", TimeSpan.FromHours(-26), true);
		}

		[Test]
		public void Test_Literal_Minutes()
		{
			ExpectSfeel(@"duration(""PT15M"")", TimeSpan.FromMinutes(15), true);
		}

		[Test]
		public void Test_Literal_Minutes_negative()
		{
			ExpectSfeel(@"duration(""-PT15M"")", TimeSpan.FromMinutes(-15), true);
		}

		[Test]
		public void Test_Literal_Seconds()
		{
			ExpectSfeel(@"duration(""PT10S"")", TimeSpan.FromSeconds(10), true);
		}

		[Test]
		public void Test_Literal_Seconds_negative()
		{
			ExpectSfeel(@"duration(""-PT10S"")", TimeSpan.FromSeconds(-10), true);
		}

		[TestCase(20, false)]
		[TestCase(21, true)]
		[TestCase(24, false)]
		[TestCase(25, true)]
		[TestCase(26, false)]
		public void Test_not_List(int hours, bool expected)
		{
			ExpectSfeel(@"not(duration(""PT26H""), duration(""P1D""), duration(""PT20H""))", TimeSpan.FromHours(hours), expected);
		}

		[TestCase(1, -1, false)]
		[TestCase(1, 0, true)]
		[TestCase(2, 0, true)]
		[TestCase(2, 1, false)]
		public void Test_Range(int hours, int ms, bool expected)
		{
			ExpectSfeel(
				@"[duration(""PT1H"")..duration(""PT2H"")]",
				TimeSpan.FromHours(hours).Add(TimeSpan.FromMilliseconds(ms)),
				expected
				);
		}
	}
}