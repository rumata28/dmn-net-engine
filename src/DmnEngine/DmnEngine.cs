using Softengi.DmnEngine.XmlTypes;

namespace Softengi.DmnEngine
{
	public class DmnEngine
	{
		public DmnEngine(Definitions definitions)
		{
			_definitions = definitions;
		}

		public void Evaluate(object inputs)
		{
		}

		private readonly Definitions _definitions;
	}
}