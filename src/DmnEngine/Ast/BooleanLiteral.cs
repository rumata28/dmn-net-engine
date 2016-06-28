namespace Softengi.DmnEngine.Ast
{
	public class BooleanLiteral : Literal<bool>, ILogical
	{
		public BooleanLiteral(bool value) : base(value)
		{}

		public void Accept(AstVisitor v)
		{
			v.VisitBooleanLiteral(this);
		}
	}
}