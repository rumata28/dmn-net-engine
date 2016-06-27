namespace Softengi.DmnEngine.SFeel.Ast
{
	public interface INode
	{
		void Accept(AstVisitor v);
	}
}