using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class UnaryTests : DmnElement
	{
		[XmlElement("text")]
		public string Text;

		[XmlAttribute("expressionLanguage", DataType = "anyURI")]
		public string ExpressionLanguage;
	}
}