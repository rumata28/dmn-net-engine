using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("association", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class Association : Artifact
	{
		[XmlElement("sourceRef")]
		public DmnElementReference SourceRef;

		[XmlElement("targetRef")]
		public DmnElementReference TargetRef;

		[XmlAttribute("associationDirection")]
		[DefaultValue(AssociationDirection.None)]
		public AssociationDirection AssociationDirection = AssociationDirection.None;
	}
}