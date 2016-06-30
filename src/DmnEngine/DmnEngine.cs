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
			var parser = new FeelParser();
			//parser. UNARY_START
			parser.Parse(unaryTests, Token.UNARY_START);
			var root = parser.Root;

			var evalVisitor = new EvaluatorVisitor {ContextValue = value};
			root.Accept(evalVisitor);
			var result = evalVisitor.PopResult();

			return result;
		}

		private readonly Definitions _definitions;
	}
}