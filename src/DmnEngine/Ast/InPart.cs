namespace Softengi.DmnEngine.Ast
{
	public class InPart : ILogical
	{
		public InPart(IExpression value, IExpression list)
		{
			Value = value;
			List = list;
		}

		public IExpression Value;
		public IExpression List;

		public void Accept(AstVisitor v)
		{
			v.VisitInPart(this);
		}
	}
}