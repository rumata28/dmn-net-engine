namespace Softengi.DmnEngine.SFeel.Ast
{
	public abstract class AstVisitor
	{
		public abstract void VisitComparison(Comparison comparison);
		public abstract void VisitRange(Range range);

		public abstract void VisitInputValue(InputValue input);
		public abstract void VisitNot(Not not);
		public abstract void VisitOr(Or or);
		public abstract void VisitQualifiedName(QualifiedName qn);

		public abstract void VisitNumericLiteral(NumericLiteral numericLiteral);
		public abstract void VisitBooleanLiteral(BooleanLiteral booleanLiteral);
		public abstract void VisitStringLiteral(StringLiteral numericLiteral);
		public abstract void VisitDateTimeLiteral(DateTimeLiteral dateTimeLiteral);
	}
}