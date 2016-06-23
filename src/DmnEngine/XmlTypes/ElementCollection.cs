using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("elementCollection", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class ElementCollection : NamedElement
	{
		[XmlElement("drgElement")]
		public DmnElementReference[] DrgElement;
	}
}