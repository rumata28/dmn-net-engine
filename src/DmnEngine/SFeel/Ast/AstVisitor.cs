namespace Softengi.DmnEngine.SFeel.Ast
{
	public abstract class AstVisitor
	{
		public abstract void VisitComparison(Comparison comparison);
		public abstract void VisitRange(Range range);

		public abstract void VisitInputValue(InputValue input);
		public abstract void VisitLiteral<T>(Literal<T> literal);
		public abstract void VisitNot(Not not);
		public abstract void VisitOr(Or or);
		public abstract void VisitQualifiedName(QualifiedName qn);
	}
}