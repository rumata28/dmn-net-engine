using Softengi.DmnEngine.Evaluation;
using Softengi.DmnEngine.Parser;
using Softengi.DmnEngine.XmlTypes;

namespace Softengi.DmnEngine
{
	public class DmnEngine
	{
		public DmnEngine(Definitions definitions)
		{
			_definitions = definitions;
		}

		static public EvaluationValue EvaluateUnaryTest(string unaryTests, EvaluationValue value)
		{
			return Evaluate(unaryTests, value, Token.UNARY_START);
		}

		static public EvaluationValue EvaluateExpression(string unaryTests, EvaluationValue value)
		{
			return Evaluate(unaryTests, value, Token.EXPRESSION_START);
		}

		static private EvaluationValue Evaluate(string unaryTests, EvaluationValue value, Token startToken)
		{
			var parser = new FeelParser();
			parser.Parse(unaryTests, startToken);

			var evalVisitor = new EvaluatorVisitor {ContextValue = value};
			parser.Root.Accept(evalVisitor);
			return evalVisitor.PopResult();
		}

		private readonly Definitions _definitions;
	}
}