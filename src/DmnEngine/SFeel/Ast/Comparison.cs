namespace Softengi.DmnEngine.SFeel.Ast
{
	public class Comparison : Logical
	{
		public Comparison(ComparisonOperator comparisonOperator, AstNode left, AstNode right)
		{
			ComparisonOperator = comparisonOperator;
			Left = left;
			Right = right;
		}

		public ComparisonOperator ComparisonOperator;
		public AstNode Left, Right;
	}
}