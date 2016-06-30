using System.Collections.Generic;

namespace Softengi.DmnEngine.Ast
{
	public class ExpressionList
	{
		public ExpressionList(List<IExpression> expressions)
		{
			Expressions = expressions;
		}

		public void Add(IExpression expression)
		{
			Expressions.Add(expression);
		}

		public List<IExpression> Expressions;
	}
}