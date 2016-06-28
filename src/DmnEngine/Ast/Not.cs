namespace Softengi.DmnEngine.Ast
{
	public class Not : ILogical
	{
		public Not(ILogical item)
		{
			Item = item;
		}

		public ILogical Item;

		public void Accept(AstVisitor v)
		{
			v.VisitNot(this);
		}
	}
}