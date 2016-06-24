using System.Collections.Generic;

namespace Softengi.DmnEngine.SFeel.Ast
{
	public class Or : Logical
	{
		public Or(params Logical[] comparisons)
		{
			Comparisons = new List<Logical>();
			foreach (var c in comparisons)
			{
				var or = c as Or;
				if (or != null)
					Comparisons.AddRange(or.Comparisons);
				else
					Comparisons.Add(c);
			}
		}

		public List<Logical> Comparisons;
	}
}