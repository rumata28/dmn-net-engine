namespace Softengi.DmnEngine.Ast
{
	public class PathExpression : IExpression
	{
		public PathExpression(IExpression expression, string name)
		{
			Expression = expression;
			Name = name;
		}

		public IExpression Expression;
		public string Name;

		public void Accept(AstVisitor v)
		{
			v.VisitPath(this);
		}
	}
}