using System;
using System.Xml;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class OutputClause : DmnElement
	{
		[XmlElement("outputValues")]
		public UnaryTests OutputValues;

		[XmlElement("defaultOutputEntry")]
		public LiteralExpression DefaultOutputEntry;

		[XmlAttribute("name")]
		public string Name;

		[XmlAttribute("typeRef")]
		public XmlQualifiedName TypeRef;
	}
}