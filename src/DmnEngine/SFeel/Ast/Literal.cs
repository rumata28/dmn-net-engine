using System;

namespace Softengi.DmnEngine.SFeel.Ast
{
	public abstract class Literal<T>
	{
		protected Literal(T value)
		{
			Value = value;
		}

		public T Value;
	}

	public class NumericLiteral : Literal<decimal>, INode
	{
		public NumericLiteral(decimal value) : base(value)
		{}

		public void Accept(AstVisitor v)
		{
			v.VisitNumericLiteral(this);
		}
	}

	public class StringLiteral : Literal<string>, INode
	{
		public StringLiteral(string value) : base(value)
		{}

		public void Accept(AstVisitor v)
		{
			v.VisitStringLiteral(this);
		}
	}

	public class DateTimeLiteral : Literal<DateTime>, INode
	{
		public DateTimeLiteral(DateTime value) : base(value)
		{}

		public void Accept(AstVisitor v)
		{
			v.VisitDateTimeLiteral(this);
		}
	}
}