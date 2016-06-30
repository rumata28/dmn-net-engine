namespace Softengi.DmnEngine.Ast
{
	public class Neg : IExpression
	{
		public Neg(IExpression item)
		{
			Item = item;
		}

		public IExpression Item;

		public void Accept(AstVisitor v)
		{
			v.VisitNeg(this);
		}
	}
}