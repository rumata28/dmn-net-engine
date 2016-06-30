using System;
using System.IO;
using System.Text;

using Softengi.DmnEngine.Ast;

namespace Softengi.DmnEngine.Parser
{
	internal partial class FeelParser
	{
		public FeelParser() : base(null)
		{}

		public INode Root;

		public void Parse(string s)
		{
			Parse(new MemoryStream(Encoding.Default.GetBytes(s)));
		}

		public void Parse(Stream stream)
		{
			Scanner = new FeelScanner(stream);
			Parse();
		}

		private void Debug(string rule)
		{
			Console.WriteLine("rule: {0}", rule);
		}
	}
}