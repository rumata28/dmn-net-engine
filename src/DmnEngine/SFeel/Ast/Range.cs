namespace Softengi.DmnEngine.SFeel.Ast
{
	public class Range : ILogical
	{
		public Range(bool openedStart, bool openedEnd, INode start, INode end, INode value)
		{
			OpenedStart = openedStart;
			OpenedEnd = openedEnd;
			Start = start;
			End = end;
			Value = value;
		}

		public bool OpenedStart, OpenedEnd;
		public INode Start, End, Value;

		public void Accept(AstVisitor v)
		{
			v.VisitRange(this);
		}
	}
}