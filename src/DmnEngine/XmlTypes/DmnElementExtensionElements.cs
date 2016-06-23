using System;
using System.Xml;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(AnonymousType = true, Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class DmnElementExtensionElements
	{
		[XmlAnyElement]
		public XmlElement[] Any;
	}
}