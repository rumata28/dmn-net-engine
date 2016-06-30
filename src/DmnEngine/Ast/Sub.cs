namespace Softengi.DmnEngine.Ast
{
	public class Sub : IExpression
	{
		public Sub(IExpression left, IExpression right)
		{
			Left = left;
			Right = right;
		}

		public IExpression Left, Right;

		public void Accept(AstVisitor v)
		{
			v.VisitSub(this);
		}
	}
}