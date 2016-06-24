namespace Softengi.DmnEngine.SFeel.Ast
{
	public class QualifiedName : AstNode
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
	}
}