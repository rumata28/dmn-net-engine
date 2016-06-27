using System;
using System.IO;
using System.Text;

using Softengi.DmnEngine.SFeel.Ast;

namespace Softengi.DmnEngine.SFeel.Parser
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
	}
}