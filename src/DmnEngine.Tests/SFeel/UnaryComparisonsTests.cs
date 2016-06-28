using System;

using NUnit.Framework;

namespace DmnEngine.Tests.SFeel
{
	[TestFixture]
	public class TimeUnaryComparisonsTests : SfeelTester
	{
		[Test]
		public void Test_Literal_Time()
		{
			ExpectSfeel(@"time(""09:05:15"")", new DateTime(1, 1, 1, 9, 5, 15), true);
		}
	}
}