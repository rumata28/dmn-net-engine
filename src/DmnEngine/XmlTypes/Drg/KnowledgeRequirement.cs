using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	/// <summary>
	/// The invocation of a Business Knowledge Model by the decision logic of a Decision.
	/// </summary>
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class KnowledgeRequirement
	{
		[XmlElement("requiredKnowledge")]
		public DmnElementReference RequiredKnowledge;
	}
}