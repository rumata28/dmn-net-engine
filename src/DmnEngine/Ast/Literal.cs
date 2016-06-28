namespace Softengi.DmnEngine.Ast
{
	public abstract class Literal<T>
	{
		protected Literal(T value)
		{
			Value = value;
		}

		public T Value;
	}
}