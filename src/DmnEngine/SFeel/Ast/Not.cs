namespace Softengi.DmnEngine.SFeel.Ast
{
	public class Not : ILogical
	{
		public Not(ILogical logical)
		{
			Logical = logical;
		}

		public ILogical Logical;

		public void Accept(AstVisitor v)
		{
			v.VisitNot(this);
		}
	}
}