using System.Collections.Generic;

namespace Softengi.DmnEngine.Ast
{
	public class And : ILogical
	{
		public And(params ILogical[] comparisons)
		{
			Items = new List<ILogical>();
			foreach (var c in comparisons)
			{
				var or = c as And;
				if (or != null)
					Items.AddRange(or.Items);
				else
					Items.Add(c);
			}
		}

		public List<ILogical> Items;

		public void Accept(AstVisitor v)
		{
			v.VisitAnd(this);
		}
	}
}