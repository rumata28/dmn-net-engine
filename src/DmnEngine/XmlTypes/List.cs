using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("list", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class List : Expression
	{
		[XmlElement("context", typeof(Context))]
		[XmlElement("decisionTable", typeof(DecisionTable))]
		[XmlElement("functionDefinition", typeof(FunctionDefinition))]
		[XmlElement("invocation", typeof(Invocation))]
		[XmlElement("list", typeof(List))]
		[XmlElement("literalExpression", typeof(LiteralExpression))]
		[XmlElement("relation", typeof(Relation))]
		public Expression[] Items;
	}
}