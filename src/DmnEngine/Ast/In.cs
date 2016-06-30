namespace Softengi.DmnEngine.Ast
{
	public class In : ILogical
	{
		public In(IExpression value, ILogical tests)
		{
			Value = value;
			Tests = tests;
		}

		public void Accept(AstVisitor v)
		{
			v.VisitIn(this);
		}

		public IExpression Value { get; }
		public ILogical Tests { get; }
	}
}