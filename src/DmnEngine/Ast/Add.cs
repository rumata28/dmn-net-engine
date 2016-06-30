namespace Softengi.DmnEngine.Ast
{
	public class Add : IExpression
	{
		public Add(IExpression addend1, IExpression addend2)
		{
			Addend1 = addend1;
			Addend2 = addend2;
		}

		public IExpression Addend1, Addend2;

		public void Accept(AstVisitor v)
		{
			v.VisitAdd(this);
		}
	}
}