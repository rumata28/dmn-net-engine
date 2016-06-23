using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	/// <summary>
	/// The act of determining an output from a number of inputs,
	/// using decision logic which may reference one or more Business Knowledge Models.
	/// </summary>
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("decision", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class Decision : DrgElement
	{
		[XmlElement("question")]
		public string Question;

		[XmlElement("allowedAnswers")]
		public string AllowedAnswers;

		[XmlElement("variable")]
		public InformationItem Variable;

		[XmlElement("informationRequirement")]
		public InformationRequirement[] InformationRequirement;

		[XmlElement("knowledgeRequirement")]
		public KnowledgeRequirement[] KnowledgeRequirement;

		[XmlElement("authorityRequirement")]
		public AuthorityRequirement[] AuthorityRequirement;

		[XmlElement("supportedObjective")]
		public DmnElementReference[] SupportedObjective;

		[XmlElement("impactedPerformanceIndicator")]
		public DmnElementReference[] ImpactedPerformanceIndicator;

		[XmlElement("decisionMaker")]
		public DmnElementReference[] DecisionMaker;

		[XmlElement("decisionOwner")]
		public DmnElementReference[] DecisionOwner;

		[XmlElement("usingProcess")]
		public DmnElementReference[] UsingProcess;

		[XmlElement("usingTask")]
		public DmnElementReference[] UsingTask;

		[XmlElement("context", typeof(Context))]
		[XmlElement("decisionTable", typeof(DecisionTable))]
		[XmlElement("functionDefinition", typeof(FunctionDefinition))]
		[XmlElement("invocation", typeof(Invocation))]
		[XmlElement("list", typeof(List))]
		[XmlElement("literalExpression", typeof(LiteralExpression))]
		[XmlElement("relation", typeof(Relation))]
		public Expression Item;
	}
}