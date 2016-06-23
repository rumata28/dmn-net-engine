using System;
using System.Xml;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[XmlInclude(typeof(Artifact))]
	[XmlInclude(typeof(Association))]
	[XmlInclude(typeof(TextAnnotation))]
	[XmlInclude(typeof(NamedElement))]
	[XmlInclude(typeof(DecisionService))]
	[XmlInclude(typeof(BusinessContextElement))]
	[XmlInclude(typeof(OrganizationUnit))]
	[XmlInclude(typeof(PerformanceIndicator))]
	[XmlInclude(typeof(ElementCollection))]
	[XmlInclude(typeof(InformationItem))]
	[XmlInclude(typeof(DrgElement))]
	[XmlInclude(typeof(KnowledgeSource))]
	[XmlInclude(typeof(InputData))]
	[XmlInclude(typeof(BusinessKnowledgeModel))]
	[XmlInclude(typeof(Decision))]
	[XmlInclude(typeof(ItemDefinition))]
	[XmlInclude(typeof(Definitions))]
	[XmlInclude(typeof(DecisionRule))]
	[XmlInclude(typeof(OutputClause))]
	[XmlInclude(typeof(UnaryTests))]
	[XmlInclude(typeof(InputClause))]
	[XmlInclude(typeof(Expression))]
	[XmlInclude(typeof(List))]
	[XmlInclude(typeof(Relation))]
	[XmlInclude(typeof(FunctionDefinition))]
	[XmlInclude(typeof(Context))]
	[XmlInclude(typeof(DecisionTable))]
	[XmlInclude(typeof(Invocation))]
	[XmlInclude(typeof(LiteralExpression))]
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class DmnElement
	{
		[XmlElement("description")]
		public string Description;

		[XmlElement("extensionElements")]
		public DmnElementExtensionElements ExtensionElements;

		[XmlAttribute("id", DataType = "ID")]
		public string ID;

		[XmlAttribute("label")]
		public string Label;

		[XmlAnyAttribute]
		public XmlAttribute[] AnyAttr;
	}
}