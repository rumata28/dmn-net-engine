using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class AuthorityRequirement
	{
		[XmlElement("requiredAuthority", typeof(DmnElementReference))]
		[XmlElement("requiredDecision", typeof(DmnElementReference))]
		[XmlElement("requiredInput", typeof(DmnElementReference))]
		[XmlChoiceIdentifier("ItemElementName")]
		public DmnElementReference Item;

		[XmlIgnore]
		public ChoiceType ItemElementName;

		[Serializable]
		[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IncludeInSchema = false)]
		public enum ChoiceType
		{
			[XmlEnum("requiredAuthority")]
			RequiredAuthority,

			[XmlEnum("requiredDecision")]
			RequiredDecision,

			[XmlEnum("requiredDecision")]
			RequiredInput
		}
	}
}