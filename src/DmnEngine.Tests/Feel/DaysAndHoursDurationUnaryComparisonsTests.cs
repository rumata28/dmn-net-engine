using System;

using NUnit.Framework;

namespace Softengi.DmnEngine.Tests.Feel
{
	[TestFixture]
	public class DaysAndHoursDurationUnaryComparisonsTests : FeelTester
	{
		[TestCase(26, 0, false)]
		[TestCase(26, 1, true)]
		public void Test_GreaterThan(int hours, int ms, bool expected)
		{
			ExpectFeel(@">duration(""PT26H"")", TimeSpan.FromHours(hours).Add(TimeSpan.FromMilliseconds(ms)), expected);
		}

		[TestCase(26, -1, false)]
		[TestCase(26, 0, true)]
		[TestCase(26, 1, true)]
		public void Test_GreaterThanOrEqual(int hours, int ms, bool expected)
		{
			ExpectFeel(@">=duration(""PT26H"")", TimeSpan.FromHours(hours).Add(TimeSpan.FromMilliseconds(ms)), expected);
		}

		[TestCase(26, -1, true)]
		[TestCase(26, 0, false)]
		public void Test_LessThan(int hours, int ms, bool expected)
		{
			ExpectFeel(@"<duration(""PT26H"")", TimeSpan.FromHours(hours).Add(TimeSpan.FromMilliseconds(ms)), expected);
		}

		[TestCase(26, -1, true)]
		[TestCase(26, 0, true)]
		[TestCase(26, 1, false)]
		public void Test_LessThanOrEqual(int hours, int ms, bool expected)
		{
			ExpectFeel(@"<=duration(""PT26H"")", TimeSpan.FromHours(hours).Add(TimeSpan.FromMilliseconds(ms)), expected);
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

		[Test]
		public void Test_Literal_Days()
		{
			ExpectFeel(@"duration(""P1D"")", TimeSpan.FromDays(1), true);
		}

		[Test]
		public void Test_Literal_Days_negative()
		{
			ExpectFeel(@"duration(""-P1D"")", TimeSpan.FromDays(-1), true);
		}

		[Test]
		public void Test_Literal_DaysHours()
		{
			ExpectFeel(@"duration(""P1DT26H"")", TimeSpan.FromHours(50), true);
		}

		[Test]
		public void Test_Literal_DaysHours_negative()
		{
			ExpectFeel(@"duration(""-P1DT26H"")", TimeSpan.FromHours(-50), true);
		}

		[Test]
		public void Test_Literal_DaysHoursMinutesSeconds()
		{
			ExpectFeel(
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
			ExpectFeel(
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
			ExpectFeel(@"duration(""PT26H"")", TimeSpan.FromHours(26), true);
		}

		[Test]
		public void Test_Literal_Hours_negative()
		{
			ExpectFeel(@"duration(""-PT26H"")", TimeSpan.FromHours(-26), true);
		}

		[Test]
		public void Test_Literal_Minutes()
		{
			ExpectFeel(@"duration(""PT15M"")", TimeSpan.FromMinutes(15), true);
		}

		[Test]
		public void Test_Literal_Minutes_negative()
		{
			ExpectFeel(@"duration(""-PT15M"")", TimeSpan.FromMinutes(-15), true);
		}

		[Test]
		public void Test_Literal_Seconds()
		{
			ExpectFeel(@"duration(""PT10S"")", TimeSpan.FromSeconds(10), true);
		}

		[Test]
		public void Test_Literal_Seconds_negative()
		{
			ExpectFeel(@"duration(""-PT10S"")", TimeSpan.FromSeconds(-10), true);
		}

		[TestCase(20, false)]
		[TestCase(21, true)]
		[TestCase(24, false)]
		[TestCase(25, true)]
		[TestCase(26, false)]
		public void Test_not_List(int hours, bool expected)
		{
			ExpectFeel(@"not(duration(""PT26H""), duration(""P1D""), duration(""PT20H""))", TimeSpan.FromHours(hours), expected);
		}

		[TestCase(1, -1, false)]
		[TestCase(1, 0, true)]
		[TestCase(2, 0, true)]
		[TestCase(2, 1, false)]
		public void Test_Range(int hours, int ms, bool expected)
		{
			ExpectFeel(
				@"[duration(""PT1H"")..duration(""PT2H"")]",
				TimeSpan.FromHours(hours).Add(TimeSpan.FromMilliseconds(ms)),
				expected
				);
		}
	}
}