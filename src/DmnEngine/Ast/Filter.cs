namespace Softengi.DmnEngine.Ast
{
	public class Filter : IExpression
	{
		public Filter(IExpression value, ILogical test)
		{
			Value = value;
			Test = test;
		}

		public IExpression Value { get; }
		public ILogical Test { get; }

		public void Accept(AstVisitor v)
		{
			v.VisitFilter(this);
		}
	}
}