namespace Softengi.DmnEngine.Ast
{
	public class Div : IExpression
	{
		public Div(IExpression dividend, IExpression divisor)
		{
			Dividend = dividend;
			Divisor = divisor;
		}

		public IExpression Dividend, Divisor;

		public void Accept(AstVisitor v)
		{
			v.VisitDiv(this);
		}
	}
}