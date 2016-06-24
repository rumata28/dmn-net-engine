using System;

namespace Softengi.DmnEngine.SFeel.Parser
{
	internal partial class SFeelScanner
	{
		public override void yyerror(string format, params object[] args)
		{
			base.yyerror(format, args);
			Console.WriteLine(format, args);
			Console.WriteLine();
		}

		static private void Debug(string message, params object[] messageParams)
		{
			Console.WriteLine(message, messageParams);
		}

		private void Debug()
		{
			Debug("token: {0}", yytext);
		}
		
		private void GetNumber()
		{
			yylval.s = yytext;
			yylval.n = decimal.Parse(yytext);
		}
	}
}