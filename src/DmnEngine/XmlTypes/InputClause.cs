using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class InputClause : DmnElement
	{
		[XmlElement("inputExpression")]
		public LiteralExpression InputExpression;

		[XmlElement("inputValues")]
		public UnaryTests InputValues;
	}
}