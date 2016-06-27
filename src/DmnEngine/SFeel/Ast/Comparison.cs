namespace Softengi.DmnEngine.SFeel.Ast
{
	public class Comparison : ILogical
	{
		public Comparison(ComparisonOperator comparisonOperator, INode left, INode right)
		{
			ComparisonOperator = comparisonOperator;
			Left = left;
			Right = right;
		}

		public ComparisonOperator ComparisonOperator;
		public INode Left, Right;

		public void Accept(AstVisitor v)
		{
			v.VisitComparison(this);
		}
	}
}