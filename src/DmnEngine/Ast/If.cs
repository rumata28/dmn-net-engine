namespace Softengi.DmnEngine.Ast
{
	public class If : IExpression
	{
		public ILogical Condition { get; }
		public IExpression ThenExpression { get; }
		public IExpression ElseExpression { get; }

		public If(ILogical condition, IExpression thenExpression, IExpression elseExpression)
		{
			Condition = condition;
			ThenExpression = thenExpression;
			ElseExpression = elseExpression;
		}

		public void Accept(AstVisitor v)
		{
			v.VisitIf(this);
		}
	}
}