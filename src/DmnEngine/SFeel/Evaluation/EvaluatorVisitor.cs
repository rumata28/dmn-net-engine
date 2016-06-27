using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using Softengi.DmnEngine.SFeel.Ast;

namespace Softengi.DmnEngine.SFeel.Evaluation
{
	public class EvaluatorVisitor : AstVisitor
	{
		private readonly Stack<EvaluationValue> _stack = new Stack<EvaluationValue>();

		public override void VisitComparison(Comparison comparison)
		{
			var leftValue = AcceptAndPop(comparison.Left);
			var rightValue = AcceptAndPop(comparison.Right);

			// TODO: semantics
			/*
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
			*/
		}

		public override void VisitRange(Range range)
		{
			var start = AcceptAndPop(range.Start);
			var end = AcceptAndPop(range.End);
			var vaule = AcceptAndPop(range.Value);

			// TODO: range logic
		}

		public override void VisitInputValue(InputValue input)
		{
			// TODO: the visitor shall be able to resolve it
			throw new System.NotImplementedException();
		}

		public override void VisitNot(Not not)
		{
			var value = AcceptAndPop(not.Logical);

			if (value.ValueType != EvaluationValue.EvaluationValueType.Boolean)
				throw new EvaluationException("Expected boolean value.");

			_stack.Push(!value.Bool);
		}

		private EvaluationValue AcceptAndPop(INode node)
		{
			node.Accept(this);
			return _stack.Pop();
		}

		public override void VisitOr(Or or)
		{
			_stack.Push(or.Logicals.Any(l => AcceptAndPop(l) == true));
		}

		public override void VisitQualifiedName(QualifiedName qn)
		{
			// TODO: the visitor shall be able to resolve it
			throw new System.NotImplementedException();
		}

		public override void VisitNumericLiteral(NumericLiteral numericLiteral)
		{
			_stack.Push(numericLiteral.Value);
		}

		public override void VisitBooleanLiteral(BooleanLiteral numericLiteral)
		{
			_stack.Push(numericLiteral.Value);
		}

		public override void VisitStringLiteral(StringLiteral numericLiteral)
		{
			_stack.Push(numericLiteral.Value);
		}

		public override void VisitDateTimeLiteral(DateTimeLiteral numericLiteral)
		{
			_stack.Push(numericLiteral.Value);
		}
	}

	public class EvaluationException : ApplicationException
	{
		public EvaluationException()
		{}

		public EvaluationException(string message) : base(message)
		{}

		public EvaluationException(string message, Exception innerException) : base(message, innerException)
		{}

		protected EvaluationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
	}
}