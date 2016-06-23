using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public enum DecisionTableOrientation
	{
		[XmlEnum("Rule-as-Row")]
		RuleasRow,

		[XmlEnum("Rule-as-Column")]
		RuleasColumn,

		[XmlEnum("CrossTable")]
		CrossTable
	}
}