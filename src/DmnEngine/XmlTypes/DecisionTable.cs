using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("decisionTable", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class DecisionTable : Expression
	{
		public DecisionTable()
		{
			HitPolicy = HitPolicy.Unique;
			PreferredOrientation = DecisionTableOrientation.RuleasRow;
		}

		[XmlElement("input")]
		public InputClause[] Input;

		[XmlElement("output")]
		public OutputClause[] Output;

		[XmlElement("rule")]
		public DecisionRule[] Rule;

		[XmlAttribute("hitPolicy")]
		[DefaultValue(HitPolicy.Unique)]
		public HitPolicy HitPolicy;

		[XmlAttribute("aggregation")]
		public BuiltInAggregator? Aggregation;

		[XmlAttribute("preferredOrientation")]
		[DefaultValue(DecisionTableOrientation.RuleasRow)]
		public DecisionTableOrientation PreferredOrientation;

		[XmlAttribute("outputLabel")]
		public string OutputLabel;
	}
}