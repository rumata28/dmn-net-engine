namespace Softengi.DmnEngine.SFeel.Ast
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