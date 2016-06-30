namespace Softengi.DmnEngine.Ast
{
	public class Mul : IExpression
	{
		public Mul(IExpression multiplicand, IExpression multiplier)
		{
			Multiplicand = multiplicand;
			Multiplier = multiplier;
		}

		public IExpression Multiplicand, Multiplier;

		public void Accept(AstVisitor v)
		{
			v.VisitMul(this);
		}
	}
}