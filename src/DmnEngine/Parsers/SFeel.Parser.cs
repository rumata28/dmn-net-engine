using System;
using System.IO;
using System.Text;

using Softengi.DmnEngine.Ast;

namespace Softengi.DmnEngine.Parsers
{
	internal partial class SFeelParser
	{
		public SFeelParser() : base(null)
		{}

		public INode Root;

		public void Parse(string s)
		{
			Parse(new MemoryStream(Encoding.Default.GetBytes(s)));
		}

		public void Parse(Stream stream)
		{
			Scanner = new SFeelScanner(stream);
			Parse();
		}

		private void Debug(string rule)
		{
			Console.WriteLine("rule: {0}", rule);
		}
	}
}