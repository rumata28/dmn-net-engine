using System;
using System.Xml;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[XmlInclude(typeof(List))]
	[XmlInclude(typeof(Relation))]
	[XmlInclude(typeof(FunctionDefinition))]
	[XmlInclude(typeof(Context))]
	[XmlInclude(typeof(DecisionTable))]
	[XmlInclude(typeof(Invocation))]
	[XmlInclude(typeof(LiteralExpression))]
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class Expression : DmnElement
	{
		[XmlAttribute("typeRef")]
		public XmlQualifiedName TypeRef;
	}
}