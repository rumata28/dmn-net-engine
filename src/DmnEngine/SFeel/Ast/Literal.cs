namespace Softengi.DmnEngine.SFeel.Ast
{
	public class Literal<T> : AstNode
	{
		public Literal(T value)
		{
			Value = value;
		}

		public T Value;
	}
}