using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	/// <summary>
	/// Input Data or Decision output being used as input to a Decision.
	/// </summary>
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class InformationRequirement
	{
		[XmlElement("requiredDecision", typeof(DmnElementReference))]
		[XmlElement("requiredInput", typeof(DmnElementReference))]
		[XmlChoiceIdentifier("ItemElementName")]
		public DmnElementReference Item;

		[XmlIgnore]
		public ItemChoiceType ItemElementName;

		[Serializable]
		[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IncludeInSchema = false)]
		public enum ItemChoiceType
		{
			[XmlEnum("requiredDecision")]
			RequiredDecision,

			[XmlEnum("requiredInput")]
			RequiredInput
		}
	}
}