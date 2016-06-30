using System;

namespace Softengi.DmnEngine.Parser
{
	internal partial class FeelScanner
	{
		public int StartToken;

		public override void yyerror(string format, params object[] args)
		{
			base.yyerror(format, args);
			Console.WriteLine(format, args);
			Console.WriteLine();
		}

		private void UnexpectedCharacter()
		{
			throw new Exception($"Unexpected character: '{yytext}'");
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

		private void GetBool()
		{
			yylval.s = yytext;
			yylval.b = bool.Parse(yytext);
		}

		private void GetString()
		{
			yylval.s = yytext.Trim('"');
		}
	}
}