using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	/// <summary>
	/// An authority for a Business Knowledge Model or Decision. 
	/// </summary>
	/// <remarks>
	/// Knowledge sources may be defined to model governance of decision-making by people (e.g., a manager), regulatory
	/// bodies(e.g., an ombudsman), documents(e.g., a policy booklet) or bodies of legislation(e.g., a government statute).
	/// These knowledge sources may be linked together, for example to show that a decision is governed(a) by a set of
	/// regulations defined by a regulatory body, and (b)by a company policy document maintained by a manager.
	/// </remarks>
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("knowledgeSource", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class KnowledgeSource : DrgElement
	{
		[XmlElement("authorityRequirement")]
		public AuthorityRequirement[] AuthorityRequirement;

		[XmlElement("type")]
		public string Type;

		[XmlElement("owner")]
		public DmnElementReference Owner;

		[XmlAttribute("locationURI", DataType = "anyURI")]
		public string LocationUri;
	}
}