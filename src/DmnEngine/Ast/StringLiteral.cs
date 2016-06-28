namespace Softengi.DmnEngine.Ast
{
	public class StringLiteral : Literal<string>, INode
	{
		public StringLiteral(string value) : base(value)
		{}

		public void Accept(AstVisitor v)
		{
			v.VisitStringLiteral(this);
		}
	}
}