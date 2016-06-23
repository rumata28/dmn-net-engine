using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	/// <summary>
	/// A function encapsulating business knowledge, e.g., as business rules, a decision table, or an analytic model.
	/// </summary>
	/// <remarks>
	/// Business knowledge models may be used to represent specific areas of business knowledge drawn upon when making
	/// decisions.  This will allow DMN to be used as a tool for formal definition of requirements for knowledge management.
	/// Business knowledge models may be linked together to show the interdependencies between areas of knowledge (in a
	/// manner similar to that used in the existing technique of Knowledge Structure Mapping). Knowledge sources may be
	/// linked to the business knowledge models to indicate how the business knowledge is governed or maintained, for example
	/// to show that a set of business policies (the business knowledge model) is defined in a company policy document (the
	/// knowledge source).
	/// </remarks>
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("businessKnowledgeModel", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class BusinessKnowledgeModel : DrgElement
	{
		[XmlElement("encapsulatedLogic")]
		public FunctionDefinition EncapsulatedLogic;

		[XmlElement("variable")]
		public InformationItem Variable;

		[XmlElement("knowledgeRequirement")]
		public KnowledgeRequirement[] KnowledgeRequirement;

		[XmlElement("authorityRequirement")]
		public AuthorityRequirement[] AuthorityRequirement;
	}
}