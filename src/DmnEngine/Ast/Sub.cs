namespace Softengi.DmnEngine.Ast
{
	public class Sub : IExpression
	{
		public Sub(IExpression subtrahend, IExpression minuend)
		{
			Subtrahend = subtrahend;
			Minuend = minuend;
		}

		public IExpression Subtrahend, Minuend;

		public void Accept(AstVisitor v)
		{
			v.VisitSub(this);
		}
	}
}