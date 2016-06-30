namespace Softengi.DmnEngine.Ast
{
	public class Pow : IExpression
	{
		public Pow(IExpression @base, IExpression exponent)
		{
			Base = @base;
			Exponent = exponent;
		}

		public IExpression Base, Exponent;

		public void Accept(AstVisitor v)
		{
			v.VisitPow(this);
		}
	}
}