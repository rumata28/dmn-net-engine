using System.Collections.Generic;

namespace Softengi.DmnEngine.Ast
{
	public class Or : ILogical
	{
		public Or(params ILogical[] comparisons)
		{
			Items = new List<ILogical>();
			foreach (var c in comparisons)
			{
				var or = c as Or;
				if (or != null)
					Items.AddRange(or.Items);
				else
					Items.Add(c);
			}
		}

		public List<ILogical> Items;

		public void Accept(AstVisitor v)
		{
			v.VisitOr(this);
		}
	}
}