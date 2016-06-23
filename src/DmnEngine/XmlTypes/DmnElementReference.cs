using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public class DmnElementReference
	{
		[XmlAttribute("href", DataType = "anyURI")]
		public string Href;
	}
}