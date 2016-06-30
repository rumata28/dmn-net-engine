namespace Softengi.DmnEngine.Ast
{
	public abstract class AstVisitor
	{
		public abstract void VisitIf(If ifExpression);
		//public abstract void VisitFor(For forExpression);

		public abstract void VisitComparison(Comparison comparison);
		public abstract void VisitRange(Range range);
		public abstract void VisitIn(In inExpression);
		public abstract void VisitInstanceOf(InstanceOf instanceOf);
		public abstract void VisitInPart(InPart inPart);

		public abstract void VisitFilter(Filter filter);

		public abstract void VisitNot(Not not);
		public abstract void VisitOr(Or or);
		public abstract void VisitAnd(And and);

		public abstract void VisitAdd(Add add);
		public abstract void VisitSub(Sub sub);
		public abstract void VisitMul(Mul mul);
		public abstract void VisitDiv(Div div);
		public abstract void VisitPow(Pow pow);
		public abstract void VisitNeg(Neg neg);

		public abstract void VisitFunctionInvocation(FunctionInvocation funcInv);
		public abstract void VisitInputValue(InputValue input);
		public abstract void VisitQualifiedName(QualifiedName qn);
		public abstract void VisitPath(PathExpression path);

		public abstract void VisitNumericLiteral(NumericLiteral numericLiteral);
		public abstract void VisitBooleanLiteral(BooleanLiteral booleanLiteral);
		public abstract void VisitStringLiteral(StringLiteral numericLiteral);
		public abstract void VisitDateTimeLiteral(DateTimeLiteral dateTimeLiteral);
		public abstract void VisitTimeSpanLiteral(TimeSpanLiteral timeSpanLiteral);
	}
}