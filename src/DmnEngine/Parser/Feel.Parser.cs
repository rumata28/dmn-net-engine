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

		public void Parse(string s, Token start = 0)
		{
			Parse(new MemoryStream(Encoding.Default.GetBytes(s)), start);
		}

		public void Parse(Stream stream, Token start = 0)
		{
			Scanner = new FeelScanner(stream) {StartToken = (int) start};
			Parse();
		}

		private void Debug(string rule)
		{
			Console.WriteLine("rule: {0}", rule);
		}
	}
}