using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	/// <summary>
	/// Decision Requirement Graph (DRG) element
	/// </summary>
	[XmlInclude(typeof(KnowledgeSource))]
	[XmlInclude(typeof(InputData))]
	[XmlInclude(typeof(BusinessKnowledgeModel))]
	[XmlInclude(typeof(Decision))]
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class DrgElement : NamedElement
	{}
}