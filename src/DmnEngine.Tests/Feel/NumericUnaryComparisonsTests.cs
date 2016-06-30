using NUnit.Framework;

namespace Softengi.DmnEngine.Tests.Feel
{
	[TestFixture]
	public class NumericUnaryComparisonsTests : FeelTester
	{
		[TestCase(20, true)]
		[TestCase(10.1, true)]
		[TestCase(10, false)]
		public void Test_GreaterThan(decimal value, bool expectation)
		{
			ExpectFeel(">10", value, expectation);
		}

		[TestCase(20, false)]
		[TestCase(10.1, false)]
		[TestCase(10, true)]
		public void Test_not_GreaterThan(decimal value, bool expectation)
		{
			ExpectFeel("not(>10)", value, expectation);
		}

		[TestCase(20, true)]
		[TestCase(10, true)]
		[TestCase(9.999, false)]
		public void Test_GreaterThanOrEqual(decimal value, bool expectation)
		{
			ExpectFeel(">=10", value, expectation);
		}

		[TestCase(20, false)]
		[TestCase(10, false)]
		[TestCase(9.999, true)]
		public void Test_not_GreaterThanOrEqual(decimal value, bool expectation)
		{
			ExpectFeel("not(>=10)", value, expectation);
		}

		[TestCase(20, false)]
		[TestCase(10.1, false)]
		[TestCase(10, false)]
		[TestCase(9.999, true)]
		[TestCase(-20, true)]
		public void Test_LessThan(decimal value, bool expectation)
		{
			ExpectFeel("<10", value, expectation);
		}

		[TestCase(20, true)]
		[TestCase(10.1, true)]
		[TestCase(10, true)]
		[TestCase(9.999, false)]
		[TestCase(-20, false)]
		public void Test_not_LessThan(decimal value, bool expectation)
		{
			ExpectFeel("not(<10)", value, expectation);
		}

		[TestCase(20, false)]
		[TestCase(10.1, false)]
		[TestCase(10, true)]
		[TestCase(9.999, true)]
		[TestCase(-20, true)]
		public void Test_LessThanOrEqual(decimal value, bool expectation)
		{
			ExpectFeel("<=10", value, expectation);
		}

		[TestCase(20, true)]
		[TestCase(10.1, true)]
		[TestCase(10, false)]
		[TestCase(9.999, false)]
		[TestCase(-20, false)]
		public void Test_not_LessThanOrEqual(decimal value, bool expectation)
		{
			ExpectFeel("not(<=10)", value, expectation);
		}

		[TestCase(10.1, false)]
		[TestCase(10, true)]
		[TestCase(9.999, false)]
		[TestCase(-10, false)]
		public void Test_Equal(decimal value, bool expectation)
		{
			ExpectFeel("10", value, expectation);
		}

		[TestCase(10.1, true)]
		[TestCase(10, false)]
		[TestCase(9.999, true)]
		[TestCase(-10, true)]
		public void Test_not_Equal(decimal value, bool expectation)
		{
			ExpectFeel("not(10)", value, expectation);
		}

		[TestCase("10", 10, true)]
		[TestCase("-10", -10, true)]
		[TestCase("10.", 10, true)]
		[TestCase("-10.", -10, true)]
		[TestCase("10.1000", 10.1, true)]
		[TestCase("-10.1000", -10.1, true)]
		[TestCase(".1", .1, true)]
		[TestCase("-.1", -.1, true)]
		[TestCase(".100000", .1, true)]
		[TestCase("-.100000", -.1, true)]
		[TestCase("000.100000", .1, true)]
		[TestCase("-000.100000", -.1, true)]
		public void Test_Formats(string sfeel, decimal value, bool expectation)
		{
			ExpectFeel(sfeel, value, expectation);
		}

		[TestCase(0, true)]
		[TestCase(1, true)]
		[TestCase(2, false)]
		[TestCase(10, false)]
		[TestCase(10.01, true)]
		[TestCase(-10, false)]
		[TestCase(-10.01, true)]
		public void Test_CompareList(decimal value, bool expectation)
		{
			ExpectFeel(">10,<-10,0,1", value, expectation);
		}

		[TestCase(0, false)]
		[TestCase(1, false)]
		[TestCase(2, true)]
		[TestCase(10, true)]
		[TestCase(10.01, false)]
		[TestCase(-10, true)]
		[TestCase(-10.01, false)]
		public void Test_not_CompareList(decimal value, bool expectation)
		{
			ExpectFeel("not(>10,<-10,0,1)", value, expectation);
		}

		[TestCase(-5.01, false)]
		[TestCase(-5, true)]
		[TestCase(0, true)]
		[TestCase(5, true)]
		[TestCase(5.01, false)]
		public void Test_Range_Open_Open(decimal value, bool expectation)
		{
			ExpectFeel("[-5..5]", value, expectation);
		}

		[TestCase(-5.001, false)]
		[TestCase(-5, true)]
		[TestCase(0.5, true)]
		[TestCase(0.51, false)]
		public void Test_Range_vs_DecimalPoint(decimal value, bool expectation)
		{
			ExpectFeel("[-5...5]", value, expectation);
		}

		[TestCase(-5.501, false)]
		[TestCase(-5.5, true)]
		[TestCase(-1.1, true)]
		[TestCase(-1.009, false)]
		public void Test_Range_NegativeEnd(decimal value, bool expectation)
		{
			ExpectFeel("[-5.5..-1.1]", value, expectation);
		}

		[Test]
		public void Test_Spaces()
		{
			ExpectFeel("	 [	-  5.5    ..	 -   1.1 ] ", -5.501m, false);
		}

		[TestCase(-5.01, false)]
		[TestCase(-5, true)]
		[TestCase(0, true)]
		[TestCase(5, false)]
		[TestCase(5.01, false)]
		[TestCase(-5.01, false)]
		[TestCase(-5, true)]
		[TestCase(0, true)]
		[TestCase(5, false)]
		[TestCase(5.01, false)]
		public void Test_Range_Open_Close(decimal value, bool expectation)
		{
			ExpectFeel("[-5..5)", value, expectation);
		}

		[TestCase(-5.01, false)]
		[TestCase(-5, false)]
		[TestCase(0, true)]
		[TestCase(5, true)]
		[TestCase(5.01, false)]
		[TestCase(-5.01, false)]
		[TestCase(-5, false)]
		[TestCase(0, true)]
		[TestCase(5, true)]
		[TestCase(5.01, false)]
		public void Test_Range_Close_Open(decimal value, bool expectation)
		{
			ExpectFeel("(-5..5]", value, expectation);
		}

		[TestCase(-5.01, false)]
		[TestCase(-5, false)]
		[TestCase(0, true)]
		[TestCase(5, false)]
		[TestCase(5.01, false)]
		public void Test_Range_Close_Close(decimal value, bool expectation)
		{
			ExpectFeel("(-5..5)", value, expectation);
		}

		[TestCase(-5.001, true)]
		[TestCase(-5, false)]
		[TestCase(0.5, false)]
		[TestCase(0.51, true)]
		public void Test_not_Range(decimal value, bool expectation)
		{
			ExpectFeel("not([-5...5])", value, expectation);
		}

		[TestCase(-5.01, false)]
		[TestCase(-5, true)]
		[TestCase(-4, true)]
		[TestCase(.99, false)]
		[TestCase(1, true)]
		[TestCase(2, true)]
		[TestCase(2.01, false)]
		public void Test_Range_List(decimal value, bool expectation)
		{
			ExpectFeel("[-5..-4],[1..2]", value, expectation);
		}

		[TestCase(-5.01, true)]
		[TestCase(-5, false)]
		[TestCase(-4, false)]
		[TestCase(.99, true)]
		[TestCase(1, false)]
		[TestCase(2, false)]
		[TestCase(2.01, true)]
		public void Test_not_Range_List(decimal value, bool expectation)
		{
			ExpectFeel("not([-5..-4],[1..2])", value, expectation);
		}

		[TestCase(-10, true)]
		[TestCase(-9.99, false)]
		[TestCase(-5.01, false)]
		[TestCase(-5, true)]
		[TestCase(-4, true)]
		[TestCase(0, true)]
		[TestCase(.99, false)]
		[TestCase(1, true)]
		[TestCase(2, true)]
		[TestCase(2.01, false)]
		[TestCase(10, false)]
		[TestCase(10.001, true)]
		public void Test_combined_Range(decimal value, bool expectation)
		{
			ExpectFeel("<=-10,[-5..-4],0,[1..2],>10", value, expectation);
		}

		[TestCase(-10, false)]
		[TestCase(-9.99, true)]
		[TestCase(-5.01, true)]
		[TestCase(-5, false)]
		[TestCase(-4, false)]
		[TestCase(0, false)]
		[TestCase(.99, true)]
		[TestCase(1, false)]
		[TestCase(2, false)]
		[TestCase(2.01, true)]
		[TestCase(10, true)]
		[TestCase(10.001, false)]
		public void Test_not_combined_Range(decimal value, bool expectation)
		{
			ExpectFeel("not(<=-10,[-5..-4],0,[1..2],>10)", value, expectation);
		}
	}
}