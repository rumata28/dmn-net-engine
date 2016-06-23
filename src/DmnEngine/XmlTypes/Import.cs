using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[XmlInclude(typeof(ImportedValues))]
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("import", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class Import
	{
		[XmlAttribute("namespace", DataType = "anyURI")]
		public string Namespace;

		[XmlAttribute("locationURI", DataType = "anyURI")]
		public string LocationUri;

		[XmlAttribute("importType", DataType = "anyURI")]
		public string ImportType;
	}
}