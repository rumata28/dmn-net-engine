namespace Softengi.DmnEngine.SFeel.Ast
{
	public class Range : Logical
	{
		public Range(bool openedStart, bool openedEnd, AstNode start, AstNode end, AstNode value)
		{
			OpenedStart = openedStart;
			OpenedEnd = openedEnd;
			Start = start;
			End = end;
			Value = value;
		}

		public bool OpenedStart, OpenedEnd;
		public AstNode Start, End, Value;
	}
}