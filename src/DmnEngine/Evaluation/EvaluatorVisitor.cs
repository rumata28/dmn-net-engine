using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Softengi.DmnEngine.Ast;

namespace Softengi.DmnEngine.Evaluation
{
	public class EvaluatorVisitor : AstVisitor
	{
		public EvaluationValue PopResult()
		{
			return _stack.Pop();
		}

		public override void VisitIf(If ifExpression)
		{
			var conditionResult = AcceptAndPop(ifExpression.Condition);
			_stack.Push(
				conditionResult
					? AcceptAndPop(ifExpression.ThenExpression)
					: AcceptAndPop(ifExpression.ElseExpression)
				);
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

		public override void VisitIn(In inExpression)
		{
			var value = AcceptAndPop(inExpression.Value);
			var list = AcceptAndPop(inExpression.Tests);

			throw new NotImplementedException();
		}

		public override void VisitInstanceOf(InstanceOf instanceOf)
		{
			throw new NotImplementedException();
		}

		public override void VisitInPart(InPart inPart)
		{
			throw new NotImplementedException();
		}

		public override void VisitFilter(Filter filter)
		{
			throw new NotImplementedException();
		}

		public override void VisitNeg(Neg neg)
		{
			var result = AcceptAndPop(neg.Item);
			if (result.ValueType != EvaluationValue.EvaluationValueType.Number)
				throw new EvaluateException(
					$"Arithmetic negation is not supported for {result.ValueType} data type.  A numbers is expected.");

			_stack.Push(-result);
		}

		public override void VisitFunctionInvocation(FunctionInvocation funcInv)
		{
			throw new NotImplementedException();
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

		public override void VisitAnd(And and)
		{
			_stack.Push(and.Items.All(l => AcceptAndPop(l) == true));
		}

		public override void VisitAdd(Add add)
		{
			var r = FeelMath.Add(AcceptAndPop(add.Addend1), AcceptAndPop(add.Addend2));
			_stack.Push(r);
		}

		public override void VisitSub(Sub sub)
		{
			var r = FeelMath.Sub(AcceptAndPop(sub.Subtrahend), AcceptAndPop(sub.Minuend));
			_stack.Push(r);
		}

		public override void VisitMul(Mul mul)
		{
			var r = FeelMath.Mul(AcceptAndPop(mul.Multiplicand), AcceptAndPop(mul.Multiplier));
			_stack.Push(r);
		}

		public override void VisitDiv(Div div)
		{
			var r = FeelMath.Div(AcceptAndPop(div.Dividend), AcceptAndPop(div.Divisor));
			_stack.Push(r);
		}

		public override void VisitPow(Pow pow)
		{
			 var r = FeelMath.Power(AcceptAndPop(pow.Base), AcceptAndPop(pow.Exponent));
			_stack.Push(r);
		}

		public override void VisitQualifiedName(QualifiedName qn)
		{
			// TODO: the visitor shall be able to resolve it
			throw new NotImplementedException();
		}

		public override void VisitPath(PathExpression path)
		{
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

		public override void VisitTimeSpanLiteral(TimeSpanLiteral timeSpanLiteral)
		{
			if (timeSpanLiteral.Duration != null)
				_stack.Push(timeSpanLiteral.Duration.Value);
			else if (timeSpanLiteral.Months != null)
				_stack.Push(EvaluationValue.Months(timeSpanLiteral.Months.Value));
			else _stack.Push(EvaluationValue.Null);
		}

		public EvaluationValue ContextValue { get; set; }

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
	}
}