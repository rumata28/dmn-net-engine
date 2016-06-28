namespace Softengi.DmnEngine.Ast
{
	public class NumericLiteral : Literal<decimal>, INode
	{
		public NumericLiteral(decimal value) : base(value)
		{}

		public void Accept(AstVisitor v)
		{
			v.VisitNumericLiteral(this);
		}
	}
}