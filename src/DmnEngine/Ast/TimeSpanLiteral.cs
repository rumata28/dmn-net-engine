using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Softengi.DmnEngine.Ast
{
	// TODO: split into 2 literals
	public class TimeSpanLiteral : INode
	{
		public TimeSpanLiteral(int? months, TimeSpan? duration = null)
		{
			Months = months;
			Duration = duration;
		}

		static public TimeSpanLiteral Parse(string value)
		{
			var m = _r.Match(value);
			if (!m.Success)
				throw new EvaluateException("Invalid time-span literal: \"" + value + "\"");

			var signGroup = m.Groups["sign"];
			int negative = signGroup.Success ? -1 : 1;

			var months = 0;

			var yearsGroup = m.Groups["Y"];
			if (yearsGroup.Success)
				months += int.Parse(yearsGroup.Value.TrimEnd('Y'))*12;

			var monthsGroup = m.Groups["M"];
			if (monthsGroup.Success)
				months += int.Parse(monthsGroup.Value.TrimEnd('M'));

			var duration = new TimeSpan();
			var daysGroup = m.Groups["D"];
			if (daysGroup.Success)
				duration += TimeSpan.FromDays(negative * int.Parse(daysGroup.Value.TrimEnd('D')));
			var hoursGroup = m.Groups["H"];
			if (hoursGroup.Success)
				duration += TimeSpan.FromHours(negative * int.Parse(hoursGroup.Value.TrimEnd('H')));
			var minutesGroup = m.Groups["m"];
			if (minutesGroup.Success)
				duration += TimeSpan.FromMinutes(negative * int.Parse(minutesGroup.Value.TrimEnd('M')));
			var secondsGroup = m.Groups["S"];
			if (secondsGroup.Success)
				duration += TimeSpan.FromSeconds(negative * int.Parse(secondsGroup.Value.TrimEnd('S')));

			return new TimeSpanLiteral(
				months == 0 ? (int?) null : months * negative,
				duration.Ticks == 0 ? (TimeSpan?) null : duration);
		}

		public void Accept(AstVisitor v)
		{
			v.VisitTimeSpanLiteral(this);
		}

		/// <summary>
		/// "Years and months" part.  Value is in months.
		/// </summary>
		public int? Months { get; }

		/// <summary>
		/// "Days and hours" part.
		/// </summary>
		public TimeSpan? Duration { get; }

		static private readonly Regex _r = new Regex(
			@"^(?<sign>-)?P(?<Y>\d+Y)?(?<M>\d+M)?(?<D>\d+D)?(T(?<H>\d+H)?(?<m>\d+M)?(?<S>\d+S)?)?$",
			RegexOptions.Compiled | RegexOptions.Singleline);
	}
}