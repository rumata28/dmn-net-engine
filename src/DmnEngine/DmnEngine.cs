using Softengi.DmnEngine.SFeel.Evaluation;
using Softengi.DmnEngine.XmlTypes;

namespace Softengi.DmnEngine
{
	public class DmnEngine
	{
		public DmnEngine(Definitions definitions)
		{
			_definitions = definitions;
		}

		public EvaluationValue EvaluateSFeel(string unaryTests, EvaluationValue value)
		{
			var parser = new SFeel.Parser.SFeelParser();
			parser.Parse(unaryTests);
			var root = parser.Root;

			var evalVisitor = new EvaluatorVisitor();
			evalVisitor.ContextValue = value;
			root.Accept(evalVisitor);
			var result = evalVisitor.PopResult();

			return result;
		}

		private readonly Definitions _definitions;
	}
}