namespace Softengi.DmnEngine.Ast
{
	public class ContextEntryList 
	{}

	public class FunctionInvocation : IExpression
	{
		public IExpression Function;
		public IParamList ParamList;

		public void Accept(AstVisitor v)
		{
			v.VisitFunctionInvocation(this);
		}
	}
}