namespace Softengi.DmnEngine.Ast
{
	public class Between : ILogical
	{
		public Between(INode value, INode left, INode right)
		{
			Value = value;
			Left = left;
			Right = right;
		}

		public INode Value, Left, Right;

		public void Accept(AstVisitor v)
		{
			v.VisitBetween(this);
		}
	}
}