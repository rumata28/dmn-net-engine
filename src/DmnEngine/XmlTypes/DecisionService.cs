using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("decisionService", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class DecisionService : NamedElement
	{
		[XmlElement("outputDecision")]
		public DmnElementReference[] OutputDecision;

		[XmlElement("encapsulatedDecision")]
		public DmnElementReference[] EncapsulatedDecision;

		[XmlElement("inputDecision")]
		public DmnElementReference[] InputDecision;

		[XmlElement("inputData")]
		public DmnElementReference[] InputData;
	}
}