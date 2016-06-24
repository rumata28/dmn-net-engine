namespace Softengi.DmnEngine.SFeel.Ast
{
	public class Not : Logical
	{
		public Not(Logical logical)
		{
			Logical = logical;
		}

		public Logical Logical;
	}
}