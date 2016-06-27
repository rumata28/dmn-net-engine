﻿using System;
using System.Collections.Generic;
using System.Linq;

using Softengi.DmnEngine.SFeel.Ast;

namespace Softengi.DmnEngine.SFeel.Evaluation
{
	public class EvaluatorVisitor : AstVisitor
	{
		public EvaluationValue PopResult()
		{
			return _stack.Pop();
		}

		public override void VisitComparison(Comparison comparison)
		{
			var left = AcceptAndPop(comparison.Left);
			var right = AcceptAndPop(comparison.Right);

			_stack.Push(Compare.Values(comparison.ComparisonOperator, left, right));
		}

		public override void VisitRange(Range range)
		{
			var value = AcceptAndPop(range.Value);

			// Lazy computation of "end" range: if fail comparison with start - do not calculate value of "end"
			_stack.Push(
				Compare.Values(ComparisonOperatorForRange(range.OpenedStart), AcceptAndPop(range.Start), value) &&
				Compare.Values(ComparisonOperatorForRange(range.OpenedEnd), value, AcceptAndPop(range.End))
				);
		}

		public override void VisitInputValue(InputValue input)
		{
			// TODO: the visitor shall be able to resolve it
			_stack.Push(ContextValue);
		}

		public override void VisitNot(Not not)
		{
			var value = AcceptAndPop(not.Item);
			_stack.Push(
				value.ValueType == EvaluationValue.EvaluationValueType.Boolean
					? new EvaluationValue(!value.Bool)
					: EvaluationValue.Null
				);
		}

		public override void VisitOr(Or or)
		{
			_stack.Push(or.Items.Any(l => AcceptAndPop(l) == true));
		}

		public override void VisitQualifiedName(QualifiedName qn)
		{
			// TODO: the visitor shall be able to resolve it
			throw new NotImplementedException();
		}

		public override void VisitNumericLiteral(NumericLiteral numericLiteral)
		{
			_stack.Push(numericLiteral.Value);
		}

		public override void VisitBooleanLiteral(BooleanLiteral booleanLiteral)
		{
			_stack.Push(booleanLiteral.Value);
		}

		public override void VisitStringLiteral(StringLiteral numericLiteral)
		{
			_stack.Push(numericLiteral.Value);
		}

		public override void VisitDateTimeLiteral(DateTimeLiteral dateTimeLiteral)
		{
			_stack.Push(dateTimeLiteral.Value);
		}

		static private ComparisonOperator ComparisonOperatorForRange(bool open)
		{
			return open ? ComparisonOperator.LessThanOrEqual : ComparisonOperator.LessThan;
		}

		private EvaluationValue AcceptAndPop(INode node)
		{
			node.Accept(this);
			return _stack.Pop();
		}

		private readonly Stack<EvaluationValue> _stack = new Stack<EvaluationValue>();
		public EvaluationValue ContextValue { get; set; }
	}
}