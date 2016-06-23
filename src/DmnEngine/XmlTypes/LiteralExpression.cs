using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("literalExpression", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class LiteralExpression : Expression
	{
		[XmlElement("importedValues", typeof(ImportedValues))]
		[XmlElement("text", typeof(string))]
		public object Item;

		[XmlAttribute("expressionLanguage", DataType = "anyURI")]
		public string ExpressionLanguage;
	}
}