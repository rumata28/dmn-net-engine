using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("textAnnotation", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class TextAnnotation : Artifact
	{
		[XmlElement("text")]
		public string Text;

		[XmlAttribute("textFormat")]
		[DefaultValue("text/plain")]
		public string TextFormat = "text/plain";
	}
}