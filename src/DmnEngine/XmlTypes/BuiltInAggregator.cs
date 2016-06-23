using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public enum BuiltInAggregator
	{
		[XmlEnum("SUM")]
		Sum,

		[XmlEnum("COUNT")]
		Count,

		[XmlEnum("MIN")]
		Min,

		[XmlEnum("MAX")]
		Max
	}
}