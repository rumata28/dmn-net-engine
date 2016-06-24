using System.Linq;

namespace Softengi.DmnEngine.SFeel.Ast
{
	public class AstNode
	{}


	// TODO: constant "true"
	public class NullUnaryTests : AstNode
	{}


	/*
		public class Comparison<T> : Logical where T : IComparable
		{
			public Comparison(ComparisonOperator comparisonOperator, AstNode<T> leftNode, AstNode<T> rightNone)
			{
				ComparisonOperator = comparisonOperator;
				LeftNode = leftNode;
				RightNone = rightNone;
			}

			public override bool Eval(EvaluationContext context)
			{
				var leftValue = LeftNode.Eval(context);
				var rightValue = LeftNode.Eval(context);
				var compareResult = leftValue.CompareTo(rightValue);

				switch (ComparisonOperator)
				{
					case ComparisonOperator.Equal:
						return compareResult == 0;
					case ComparisonOperator.GreaterThan:
						return compareResult > 0;
					case ComparisonOperator.GreaterThanOrEqual:
						return compareResult >= 0;
					case ComparisonOperator.LessThan:
						return compareResult < 0;
					case ComparisonOperator.LessThanOrEqual:
						return compareResult <= 0;
					default:
						throw new InvalidOperationException("Comparison operation is invalid.");
				}
			}

			public ComparisonOperator ComparisonOperator { get; }
			public AstNode<T> LeftNode { get; }
			public AstNode<T> RightNone { get; }
		}
		*/
}
