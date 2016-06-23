using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("relation", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class Relation : Expression
	{
		[XmlElement("column")]
		public InformationItem[] Column;

		[XmlElement("row")]
		public List[] Row;
	}
}