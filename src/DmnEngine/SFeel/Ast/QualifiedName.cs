namespace Softengi.DmnEngine.SFeel.Ast
{
	public class QualifiedName : INode
	{
		public QualifiedName(string name)
		{
			Name = name;
		}

		public string Name;

		public void AddComponent(string name)
		{
			Name += "." + name;
		}

		public void Accept(AstVisitor v)
		{
			v.VisitQualifiedName(this);
		}
	}
}