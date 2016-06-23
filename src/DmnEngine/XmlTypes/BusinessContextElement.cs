using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[XmlInclude(typeof(OrganizationUnit))]
	[XmlInclude(typeof(PerformanceIndicator))]
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class BusinessContextElement : NamedElement
	{
		[XmlAttribute("URI", DataType = "anyURI")]
		public string Uri;
	}
}