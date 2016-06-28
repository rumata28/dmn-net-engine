using System;

namespace Softengi.DmnEngine.Evaluation
{
	public struct EvaluationValue
	{
		static public EvaluationValue Null = new EvaluationValue {ValueType = EvaluationValueType.Null};

		public EvaluationValue(decimal number) : this()
		{
			Number = number;
			ValueType = EvaluationValueType.Number;
		}

		public EvaluationValue(bool boolean) : this()
		{
			Bool = boolean;
			ValueType = EvaluationValueType.Boolean;
		}

		public EvaluationValue(string str) : this()
		{
			String = str;
			ValueType = EvaluationValueType.String;
		}

		public EvaluationValue(DateTime dt) : this()
		{
			DateTime = dt;
			ValueType = EvaluationValueType.DateTime;
		}

		public EvaluationValue(TimeSpan ts) : this()
		{
			Duration = ts;
			ValueType = EvaluationValueType.DaysAndHoursDuration;
		}

		public EvaluationValue(EvaluationValueType yearsAndMonthsDuration, int months) : this()
		{
			ValueType = yearsAndMonthsDuration;
			Number = months;
		}

		static public EvaluationValue Years(int years, int months = 0)
		{
			return Months(years * 12 + months);
		}

		static public EvaluationValue Months(int months)
		{
			return new EvaluationValue(EvaluationValueType.YearsAndMonthsDuration, months);
		}

		static public implicit operator EvaluationValue(decimal d)
		{
			return new EvaluationValue(d);
		}

		static public implicit operator EvaluationValue(bool b)
		{
			return new EvaluationValue(b);
		}

		static public implicit operator EvaluationValue(string s)
		{
			return new EvaluationValue(s);
		}

		static public implicit operator EvaluationValue(DateTime dt)
		{
			return new EvaluationValue(dt);
		}

		static public implicit operator EvaluationValue(TimeSpan ts)
		{
			return new EvaluationValue(ts);
		}

		static public implicit operator bool(EvaluationValue ev)
		{
			if (ev.ValueType != EvaluationValueType.Boolean)
				throw new EvaluationException("Expected boolean value.");
			return ev.Bool;
		}

		static public implicit operator decimal(EvaluationValue ev)
		{
			if (ev.ValueType != EvaluationValueType.Number)
				throw new EvaluationException("Expected number value.");
			return ev.Number;
		}

		static public implicit operator string(EvaluationValue ev)
		{
			if (ev.ValueType != EvaluationValueType.String)
				throw new EvaluationException("Expected string value.");
			return ev.String;
		}

		static public implicit operator DateTime(EvaluationValue ev)
		{
			if (ev.ValueType != EvaluationValueType.DateTime)
				throw new EvaluationException("Expected DateTime value.");
			return ev.DateTime;
		}

		static public implicit operator TimeSpan(EvaluationValue ev)
		{
			if (ev.ValueType != EvaluationValueType.DaysAndHoursDuration)
				throw new EvaluationException("Expected Duration value.");
			return ev.Duration;
		}

		public EvaluationValueType ValueType;
		public decimal Number;
		public bool Bool;
		public DateTime DateTime;
		public TimeSpan Duration;
		public string String;

		public enum EvaluationValueType
		{
			Number,
			String,
			Boolean,
			DateTime,
			Time,
			DaysAndHoursDuration,
			YearsAndMonthsDuration,
			Null
		}
	}
}