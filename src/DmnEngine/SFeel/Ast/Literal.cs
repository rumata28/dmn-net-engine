namespace Softengi.DmnEngine.SFeel.Ast
{
	public class Literal<T> : INode
	{
		public Literal(T value)
		{
			Value = value;
		}

		public T Value;

		public void Accept(AstVisitor v)
		{
			v.VisitLiteral(this);
		}
	}
}