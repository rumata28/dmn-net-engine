namespace Softengi.DmnEngine.Ast
{
	public interface INode
	{
		void Accept(AstVisitor v);
	}
}