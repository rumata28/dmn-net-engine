using System;
using System.Xml.Serialization;

namespace Softengi.DmnEngine.XmlTypes
{
	/// <summary>
	/// Information used as an input by one or more Decisions.
	/// </summary>
	[Serializable]
	[XmlType(Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
	[XmlRoot("inputData", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", IsNullable = false)]
	public class InputData : DrgElement
	{
		[XmlElement("variable")]
		public InformationItem Variable;
	}
}