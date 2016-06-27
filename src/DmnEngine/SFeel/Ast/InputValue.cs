namespace Softengi.DmnEngine.SFeel.Ast
{
	/// <summary>
	/// Represent a node for input value for unary test call.
	/// </summary>
	public class InputValue : INode
	{
		public void Accept(AstVisitor v)
		{
			v.VisitInputValue(this);
		}
	}
}