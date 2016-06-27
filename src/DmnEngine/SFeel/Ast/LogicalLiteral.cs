namespace Softengi.DmnEngine.SFeel.Ast
{
	public class LogicalLiteral : Literal<bool>, ILogical
	{
		public LogicalLiteral(bool value) : base(value)
		{}
	}
}