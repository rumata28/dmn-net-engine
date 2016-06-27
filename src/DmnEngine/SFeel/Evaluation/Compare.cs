using System;
using System.Data;

using Softengi.DmnEngine.SFeel.Ast;

namespace Softengi.DmnEngine.SFeel.Evaluation
{
	static internal class Compare
	{
		static internal bool Values(ComparisonOperator comparisonOperator, EvaluationValue left, EvaluationValue right)
		{
			if (left.ValueType == right.ValueType)
			{
				switch (left.ValueType)
				{
					case EvaluationValue.EvaluationValueType.Number:
						return Numbers(comparisonOperator, left, right);
					case EvaluationValue.EvaluationValueType.Boolean:
						return Booleans(comparisonOperator, left, right);
					case EvaluationValue.EvaluationValueType.String:
						return Strings(comparisonOperator, left, right);
					case EvaluationValue.EvaluationValueType.DateTime:
						return DateTimes(comparisonOperator, left, right);
					case EvaluationValue.EvaluationValueType.Duration:
						return Durations(comparisonOperator, left, right);
				}
			}

			// TODO: compare values of different types

			throw new EvaluateException($"Cannot compare {left.ValueType} with {right.ValueType}");
		}

		static internal bool Numbers(ComparisonOperator comparisonOperator, decimal left, decimal right)
		{
			return CompareResultToBool(comparisonOperator, left.CompareTo(right));
		}

		static internal bool Booleans(ComparisonOperator comparisonOperator, bool left, bool right)
		{
			if (comparisonOperator != ComparisonOperator.Equal)
				throw new InvalidOperationException("Booleans could be compared for equality only.");
			return left == right;
		}

		static internal bool Strings(ComparisonOperator comparisonOperator, string left, string right)
		{
			if (comparisonOperator != ComparisonOperator.Equal)
				throw new InvalidOperationException("Booleans could be compared for equality only.");
			return left == right;
		}

		static internal bool Durations(ComparisonOperator comparisonOperator, TimeSpan left, TimeSpan right)
		{
			return CompareResultToBool(comparisonOperator, left.CompareTo(right));
		}

		static internal bool DateTimes(ComparisonOperator comparisonOperator, DateTime left, DateTime right)
		{
			return CompareResultToBool(comparisonOperator, left.CompareTo(right));
		}

		static private bool CompareResultToBool(ComparisonOperator comparisonOperator, int compareResult)
		{
			switch (comparisonOperator)
			{
				case ComparisonOperator.Equal:
					return compareResult == 0;
				case ComparisonOperator.GreaterThan:
					return compareResult > 0;
				case ComparisonOperator.GreaterThanOrEqual:
					return compareResult >= 0;
				case ComparisonOperator.LessThan:
					return compareResult < 0;
				case ComparisonOperator.LessThanOrEqual:
					return compareResult <= 0;
				default:
					throw new InvalidOperationException("Comparison operation is invalid.");
			}
		}
	}
}