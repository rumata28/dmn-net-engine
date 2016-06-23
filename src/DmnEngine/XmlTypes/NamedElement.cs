using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
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
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class NamedElement : DmnElement
	{
		[XmlAttribute("name")]
		public string Name;
	}
}