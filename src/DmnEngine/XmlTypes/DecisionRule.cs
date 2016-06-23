using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class DecisionRule : DmnElement
	{
		[XmlElement("inputEntry")]
		public UnaryTests[] InputEntry;

		[XmlElement("outputEntry")]
		public LiteralExpression[] OutputEntry;
	}
}