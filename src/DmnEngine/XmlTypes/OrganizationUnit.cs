using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("organizationUnit", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class OrganizationUnit : BusinessContextElement
	{
		[XmlElement("decisionMade")]
		public DmnElementReference[] DecisionMade;

		[XmlElement("decisionOwned")]
		public DmnElementReference[] DecisionOwned;
	}
}