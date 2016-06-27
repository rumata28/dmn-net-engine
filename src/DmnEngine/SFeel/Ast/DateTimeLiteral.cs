using System;

namespace Softengi.DmnEngine.SFeel.Ast
{
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