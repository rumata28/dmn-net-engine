using System;
using System.Runtime.InteropServices;

namespace Softengi.DmnEngine.SFeel.Evaluation
{
	[StructLayout(LayoutKind.Explicit)]
	public struct EvaluationValue
	{
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

		static public implicit operator bool(EvaluationValue ev)
		{
			if (ev.ValueType != EvaluationValue.EvaluationValueType.Boolean)
				throw new EvaluationException("Expected boolean value.");
			return ev.Bool;
		}

		[FieldOffset(0)]
		public decimal Number;

		[FieldOffset(0)]
		public string String;

		[FieldOffset(0)]
		public bool Bool;

		[FieldOffset(0)]
		public DateTime DateTime;

		[FieldOffset(sizeof(decimal))]
		public EvaluationValueType ValueType;

		public enum EvaluationValueType
		{
			Number,
			String,
			DateTime,
			Boolean
		}
	}
}