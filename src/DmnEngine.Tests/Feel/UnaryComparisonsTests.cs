using System;

using NUnit.Framework;

namespace Softengi.DmnEngine.Tests.Feel
{
	[TestFixture]
	public class TimeUnaryComparisonsTests : FeelTester
	{
		[Test]
		public void Test_Literal_Time()
		{
			ExpectFeel(@"time(""09:05:15"")", new DateTime(1, 1, 1, 9, 5, 15), true);
		}
	}
}