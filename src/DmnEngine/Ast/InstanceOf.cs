namespace Softengi.DmnEngine.Ast
{
	public class InstanceOf : ILogical
	{
		public InstanceOf(ILogical value, IExpression type)
		{
			Value = value;
			Type = type;
		}

		public ILogical Value { get; }
		public IExpression Type { get; }

		public void Accept(AstVisitor v)
		{
			v.VisitInstanceOf(this);
		}
	}
}