using System;
using System.Xml;

namespace Softengi.DmnEngine.Ast
{
	public class DateTimeLiteral : Literal<DateTime>, INode
	{
		public DateTimeLiteral(DateTime value) : base(value)
		{}

		static public DateTimeLiteral ParseDate(string str)
		{
			// TODO: more strict format
			var d = XmlConvert.ToDateTime(str, XmlDateTimeSerializationMode.Unspecified);
			return new DateTimeLiteral(d);
		}

		static public DateTimeLiteral ParseDateAndTime(string str)
		{
			// TODO: more strict format
			var d = XmlConvert.ToDateTime(str, XmlDateTimeSerializationMode.Unspecified);
			return new DateTimeLiteral(d);
		}

		static public DateTimeLiteral ParseTime(string str)
		{
			var d = XmlConvert.ToDateTime(str, "HH:mm:ss");
			return new DateTimeLiteral(d);
		}

		public void Accept(AstVisitor v)
		{
			v.VisitDateTimeLiteral(this);
		}
	}
}