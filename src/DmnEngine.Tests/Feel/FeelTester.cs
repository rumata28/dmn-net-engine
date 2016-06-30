using System;

using NUnit.Framework;

using Softengi.DmnEngine.Evaluation;

namespace Softengi.DmnEngine.Tests.Feel
{
	public class FeelTester : AssertionHelper
	{
		protected void ExpectFeel(string sfeelExpression, EvaluationValue input, EvaluationValue expectedResult)
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
				case EvaluationValue.EvaluationValueType.DaysAndHoursDuration:
					Expect(result.Duration, EqualTo(expectedResult.Duration));
					break;
				case EvaluationValue.EvaluationValueType.Null:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		static protected EvaluationValue SFeelEval(string feelExpression, EvaluationValue input)
		{
			return DmnEngine.EvaluateUnaryTest(feelExpression, input);
		}
	}
}