using System.Collections.Generic;

namespace Softengi.DmnEngine.SFeel.Ast
{
	public class Or : ILogical
	{
		public Or(params ILogical[] comparisons)
		{
			Logicals = new List<ILogical>();
			foreach (var c in comparisons)
			{
				var or = c as Or;
				if (or != null)
					Logicals.AddRange(or.Logicals);
				else
					Logicals.Add(c);
			}
		}

		public List<ILogical> Logicals;

		public void Accept(AstVisitor v)
		{
			v.VisitOr(this);
		}
	}
}