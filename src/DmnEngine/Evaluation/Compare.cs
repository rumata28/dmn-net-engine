using System;
using System.Data;

using Softengi.DmnEngine.Ast;

namespace Softengi.DmnEngine.Evaluation
{
	static internal class Compare
	{
		/// <remarks>
		/// The spec says:
		/// 
		/// Comparison operators are defined only when the two operands have the same type, except for years and months duration
		/// and days and time duration, which can be compared for equality. Notice, however, that “with the exception of the zerolength
		/// duration, no instance of xs:dayTimeDuration can ever be equal to an instance of xs:yearMonthDuration.” [XFO].
		/// 
		/// Remark: month duration could not be compared to days duration, because different months have different days number.  So,
		/// they could be compared only approximately, for example, if assume that 1 month is 30 days (while it could be 28, 29 or 31).
		/// </remarks>
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
					case EvaluationValue.EvaluationValueType.YearsAndMonthsDuration:
						return Numbers(comparisonOperator, left, right);
					case EvaluationValue.EvaluationValueType.DaysAndHoursDuration:
						return Durations(comparisonOperator, left, right);
					case EvaluationValue.EvaluationValueType.Null:
						return true;
				}
			}

			// TODO: equality comparison with null - exception or throw?
			// TODO: equality comparison of different types - exception or throw?

			throw new EvaluateException($"Cannot compare {left.ValueType} with {right.ValueType}");
		}

		static internal bool Numbers(ComparisonOperator comparisonOperator, decimal left, decimal right)
		{
			return CompareResultToBool(comparisonOperator, left.CompareTo(right));
		}

		static internal bool Booleans(ComparisonOperator comparisonOperator, bool left, bool right)
		{
			if (comparisonOperator != ComparisonOperator.Equal && comparisonOperator != ComparisonOperator.NotEqual)
				throw new InvalidOperationException("Booleans could be compared for equality only.");

			var equality = left == right;
			return comparisonOperator == ComparisonOperator.Equal ? equality : !equality;
		}

		static internal bool Strings(ComparisonOperator comparisonOperator, string left, string right)
		{
			if (comparisonOperator != ComparisonOperator.Equal && comparisonOperator != ComparisonOperator.NotEqual)
				throw new InvalidOperationException("Booleans could be compared for equality only.");

			var equality = left == right;
			return comparisonOperator == ComparisonOperator.Equal ? equality : !equality;
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
				case ComparisonOperator.NotEqual:
					return compareResult != 0;
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