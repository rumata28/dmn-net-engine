using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	public enum HitPolicy
	{
		[XmlEnum("UNIQUE")]
		Unique,

		[XmlEnum("FIRST")]
		First,

		[XmlEnum("PRIORITY")]
		Priority,

		[XmlEnum("ANY")]
		Any,

		[XmlEnum("COLLECT")]
		Collect,


		[XmlEnum("RULE ORDER")]
		RuleOrder,


		[XmlEnum("OUTPUT ORDER")]
		OutputOrder
	}
}