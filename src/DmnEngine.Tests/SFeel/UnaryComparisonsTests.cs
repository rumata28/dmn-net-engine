using System;

using NUnit.Framework;

using Softengi.DmnEngine.SFeel.Evaluation;

namespace DmnEngine.Tests.SFeel
{
	[TestFixture]
	public class UnaryComparisonsTests : AssertionHelper
	{
		[Test]
		public void Test_GreaterThan()
		{
			ExpectSfeel(">10", 20, true);
			ExpectSfeel(">10", 10.1m, true);
			ExpectSfeel(">10", 10, false);
		}

		[Test]
		public void Test_not_GreaterThan()
		{
			ExpectSfeel("not(>10)", 20, false);
			ExpectSfeel("not(>10)", 10.1m, false);
			ExpectSfeel("not(>10)", 10, true);
		}

		[Test]
		public void Test_GreaterThanOrEqual()
		{
			ExpectSfeel(">=10", 20, true);
			ExpectSfeel(">=10", 10, true);
			ExpectSfeel(">=10", 9.999m, false);
		}

		[Test]
		public void Test_not_GreaterThanOrEqual()
		{
			ExpectSfeel("not(>=10)", 20, false);
			ExpectSfeel("not(>=10)", 10, false);
			ExpectSfeel("not(>=10)", 9.999m, true);
		}

		[Test]
		public void Test_LessThan()
		{
			ExpectSfeel("<10", 20, false);
			ExpectSfeel("<10", 10.1m, false);
			ExpectSfeel("<10", 10, false);
			ExpectSfeel("<10", 9.999m, true);
			ExpectSfeel("<10", -20, true);
		}

		[Test]
		public void Test_not_LessThan()
		{
			ExpectSfeel("not(<10)", 20, true);
			ExpectSfeel("not(<10)", 10.1m, true);
			ExpectSfeel("not(<10)", 10, true);
			ExpectSfeel("not(<10)", 9.999m, false);
			ExpectSfeel("not(<10)", -20, false);
		}

		[Test]
		public void Test_LessThanOrEqual()
		{
			ExpectSfeel("<=10", 20, false);
			ExpectSfeel("<=10", 10.1m, false);
			ExpectSfeel("<=10", 10, true);
			ExpectSfeel("<=10", 9.999m, true);
			ExpectSfeel("<=10", -20, true);
		}

		[Test]
		public void Test_not_LessThanOrEqual()
		{
			ExpectSfeel("not(<=10)", 20, true);
			ExpectSfeel("not(<=10)", 10.1m, true);
			ExpectSfeel("not(<=10)", 10, false);
			ExpectSfeel("not(<=10)", 9.999m, false);
			ExpectSfeel("not(<=10)", -20, false);
		}

		[Test]
		public void Test_Equal()
		{
			ExpectSfeel("10", 20, false);
			ExpectSfeel("10", 10.1m, false);
			ExpectSfeel("10", 10, true);
			ExpectSfeel("10", 9.999m, false);
			ExpectSfeel("10", -10, false);
		}

		[Test]
		public void Test_not_Equal()
		{
			ExpectSfeel("not(10)", 20, true);
			ExpectSfeel("not(10)", 10.1m, true);
			ExpectSfeel("not(10)", 10, false);
			ExpectSfeel("not(10)", 9.999m, true);
			ExpectSfeel("not(10)", -10, true);
		}

		[Test]
		public void Test_Literal_Numeric()
		{
			ExpectSfeel("10", 10, true);
			ExpectSfeel("-10", -10, true);
			ExpectSfeel("10.", 10, true);
			ExpectSfeel("-10.", -10, true);
			ExpectSfeel("10.1000", 10.1m, true);
			ExpectSfeel("-10.1000", -10.1m, true);
			ExpectSfeel(".1", .1m, true);
			ExpectSfeel("-.1", -.1m, true);
			ExpectSfeel(".100000", .1m, true);
			ExpectSfeel("-.100000", -.1m, true);
			ExpectSfeel("000.100000", .1m, true);
			ExpectSfeel("-000.100000", -.1m, true);
		}

		[Test]
		public void Test_Literal_Boolean()
		{
			ExpectSfeel("true", true, true);
			ExpectSfeel("false", false, true);
		}

		[Test]
		public void Test_Literal_String()
		{
			ExpectSfeel(@"""a string""", "a string", true);
		}

		[Test]
		public void Test_CompareList()
		{
			ExpectSfeel(">10,<-10,0,1", 0, true);
			ExpectSfeel(">10,<-10,0,1", 1, true);
			ExpectSfeel(">10,<-10,0,1", 2, false);
			ExpectSfeel(">10,<-10,0,1", 10, false);
			ExpectSfeel(">10,<-10,0,1", 10.01m, true);
			ExpectSfeel(">10,<-10,0,1", -10, false);
			ExpectSfeel(">10,<-10,0,1", -10.01m, true);
		}

		[Test]
		public void Test_not_CompareList()
		{
			ExpectSfeel("not(>10,<-10,0,1)", 0, false);
			ExpectSfeel("not(>10,<-10,0,1)", 1, false);
			ExpectSfeel("not(>10,<-10,0,1)", 2, true);
			ExpectSfeel("not(>10,<-10,0,1)", 10, true);
			ExpectSfeel("not(>10,<-10,0,1)", 10.01m, false);
			ExpectSfeel("not(>10,<-10,0,1)", -10, true);
			ExpectSfeel("not(>10,<-10,0,1)", -10.01m, false);
		}

		[Test]
		public void Test_Range_Open_Open()
		{
			ExpectSfeel("[-5..5]", -5.01m, false);
			ExpectSfeel("[-5..5]", -5, true);
			ExpectSfeel("[-5..5]", 0, true);
			ExpectSfeel("[-5..5]", 5, true);
			ExpectSfeel("[-5..5]", 5.01m, false);
		}

		[Test]
		public void Test_Range_vs_DecimalPoint()
		{
			ExpectSfeel("[-5...5]", -5.001m, false);
			ExpectSfeel("[-5...5]", -5, true);
			ExpectSfeel("[-5...5]", 0.5m, true);
			ExpectSfeel("[-5...5]", 0.51m, false);
		}

		[Test]
		public void Test_Range_NegativeEnd()
		{
			ExpectSfeel("[-5.5..-1.1]", -5.501m, false);
			ExpectSfeel("[-5.5..-1.1]", -5.5m, true);
			ExpectSfeel("[-5.5..-1.1]", -1.1m, true);
			ExpectSfeel("[-5.5..-1.1]", -1.009m, false);
		}

		[Test]
		public void Test_Range_Open_Close()
		{
			ExpectSfeel("[-5..5)", -5.01m, false);
			ExpectSfeel("[-5..5)", -5, true);
			ExpectSfeel("[-5..5)", 0, true);
			ExpectSfeel("[-5..5)", 5, false);
			ExpectSfeel("[-5..5)", 5.01m, false);

			ExpectSfeel("[-5..5[", -5.01m, false);
			ExpectSfeel("[-5..5[", -5, true);
			ExpectSfeel("[-5..5[", 0, true);
			ExpectSfeel("[-5..5[", 5, false);
			ExpectSfeel("[-5..5[", 5.01m, false);
		}

		[Test]
		public void Test_Range_Close_Open()
		{
			ExpectSfeel("(-5..5]", -5.01m, false);
			ExpectSfeel("(-5..5]", -5, false);
			ExpectSfeel("(-5..5]", 0, true);
			ExpectSfeel("(-5..5]", 5, true);
			ExpectSfeel("(-5..5]", 5.01m, false);

			ExpectSfeel("]-5..5]", -5.01m, false);
			ExpectSfeel("]-5..5]", -5, false);
			ExpectSfeel("]-5..5]", 0, true);
			ExpectSfeel("]-5..5]", 5, true);
			ExpectSfeel("]-5..5]", 5.01m, false);
		}

		[Test]
		public void Test_Range_Close_Close()
		{
			ExpectSfeel("(-5..5)", -5.01m, false);
			ExpectSfeel("(-5..5)", -5, false);
			ExpectSfeel("(-5..5)", 0, true);
			ExpectSfeel("(-5..5)", 5, false);
			ExpectSfeel("(-5..5)", 5.01m, false);
		}

		[Test]
		public void Test_not_Range()
		{
			ExpectSfeel("not([-5...5])", -5.001m, true);
			ExpectSfeel("not([-5...5])", -5, false);
			ExpectSfeel("not([-5...5])", 0.5m, false);
			ExpectSfeel("not([-5...5])", 0.51m, true);
		}

		[Test]
		public void Test_Range_List()
		{
			ExpectSfeel("[-5..-4],[1..2]", -5.01m, false);
			ExpectSfeel("[-5..-4],[1..2]", -5, true);
			ExpectSfeel("[-5..-4],[1..2]", -4, true);
			ExpectSfeel("[-5..-4],[1..2]", .99m, false);
			ExpectSfeel("[-5..-4],[1..2]", 1, true);
			ExpectSfeel("[-5..-4],[1..2]", 2, true);
			ExpectSfeel("[-5..-4],[1..2]", 2.01m, false);
		}

		[Test]
		public void Test_not_Range_List()
		{
			ExpectSfeel("not([-5..-4],[1..2])", -5.01m, true);
			ExpectSfeel("not([-5..-4],[1..2])", -5, false);
			ExpectSfeel("not([-5..-4],[1..2])", -4, false);
			ExpectSfeel("not([-5..-4],[1..2])", .99m, true);
			ExpectSfeel("not([-5..-4],[1..2])", 1, false);
			ExpectSfeel("not([-5..-4],[1..2])", 2, false);
			ExpectSfeel("not([-5..-4],[1..2])", 2.01m, true);
		}

		[Test]
		public void Test_combined_Range()
		{
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", -10, true);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", -9.99m, false);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", -5.01m, false);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", -5, true);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", -4, true);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", 0, true);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", .99m, false);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", 1, true);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", 2, true);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", 2.01m, false);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", 10, false);
			ExpectSfeel("<=-10,[-5..-4],0,[1..2],>10", 10.001m, true);
		}

		[Test]
		public void Test_not_combined_Range()
		{
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", -10, false);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", -9.99m, true);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", -5.01m, true);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", -5, false);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", -4, false);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", 0, false);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", .99m, true);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", 1, false);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", 2, false);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", 2.01m, true);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", 10, true);
			ExpectSfeel("not(<=-10,[-5..-4],0,[1..2],>10)", 10.001m, false);
		}
		
		private void ExpectSfeel(string sfeelExpression, EvaluationValue input, EvaluationValue expectedResult)
		{
			var result = SFeelEval(sfeelExpression, input);
			Expect(result.ValueType, EqualTo(expectedResult.ValueType));
			switch (result.ValueType)
			{
				case EvaluationValue.EvaluationValueType.Number:
					Expect(result.Number, EqualTo(expectedResult.Number));
					break;
				case EvaluationValue.EvaluationValueType.Boolean:
					Expect(result.Bool, EqualTo(expectedResult.Bool));
					break;
				case EvaluationValue.EvaluationValueType.DateTime:
					Expect(result.DateTime, EqualTo(expectedResult.DateTime));
					break;
				case EvaluationValue.EvaluationValueType.String:
					Expect(result.String, EqualTo(expectedResult.String));
					break;
				case EvaluationValue.EvaluationValueType.Duration:
					Expect(result.Duration, EqualTo(expectedResult.Duration));
					break;
				case EvaluationValue.EvaluationValueType.Null:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		static private EvaluationValue SFeelEval(string sfeelExpression, EvaluationValue input)
		{
			var dmnEngine = new Softengi.DmnEngine.DmnEngine(null);
			return dmnEngine.EvaluateSFeel(sfeelExpression, input);
		}
	}
}
