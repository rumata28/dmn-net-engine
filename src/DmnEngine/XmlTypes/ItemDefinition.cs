using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("itemDefinition", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class ItemDefinition : NamedElement
	{
		[XmlElement("allowedValues", typeof(UnaryTests))]
		[XmlElement("itemComponent", typeof(ItemDefinition))]
		[XmlElement("typeRef", typeof(XmlQualifiedName))]
		public object[] Items;

		[XmlAttribute("typeLanguage", DataType = "anyURI")]
		public string TypeLanguage;

		[XmlAttribute("isCollection")]
		[DefaultValue(false)]
		public bool IsCollection;
	}
}