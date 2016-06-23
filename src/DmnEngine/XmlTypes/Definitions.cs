using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("definitions", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class Definitions : NamedElement
	{
		[XmlElement("import")]
		public Import[] Import;

		[XmlElement("itemDefinition")]
		public ItemDefinition[] ItemDefinition;

		[XmlElement("businessKnowledgeModel", typeof(BusinessKnowledgeModel))]
		[XmlElement("decision", typeof(Decision))]
		[XmlElement("inputData", typeof(InputData))]
		[XmlElement("knowledgeSource", typeof(KnowledgeSource))]
		public DrgElement[] DrgElements;

		[XmlElement("association", typeof(Association))]
		[XmlElement("textAnnotation", typeof(TextAnnotation))]
		public Artifact[] Items1;

		[XmlElement("elementCollection")]
		public ElementCollection[] ElementCollection;

		[XmlElement("organizationUnit", typeof(OrganizationUnit))]
		[XmlElement("performanceIndicator", typeof(PerformanceIndicator))]
		public BusinessContextElement[] Items2;

		[XmlAttribute("expressionLanguage", DataType = "anyURI")]
		[DefaultValue("http://www.omg.org/spec/FEEL/20140401")]
		public string ExpressionLanguage = "http://www.omg.org/spec/FEEL/20140401";

		[XmlAttribute("typeLanguage", DataType = "anyURI")]
		[DefaultValue("http://www.omg.org/spec/FEEL/20140401")]
		public string TypeLanguage = "http://www.omg.org/spec/FEEL/20140401";

		[XmlAttribute("namespace", DataType = "anyURI")]
		public string Namespace;

		[XmlAttribute("exporter")]
		public string Exporter;

		[XmlAttribute("exporterVersion")]
		public string ExporterVersion;
	}
}