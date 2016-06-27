%namespace Softengi.DmnEngine.SFeel.Parser
%scannertype SFeelScanner
%visibility internal
%tokentype Token

%option stack, minimize, parser, verbose, persistbuffer, noembedbuffers 

Eol					(\r\n?|\n)
NotWh				[^ \t\r\n]
S					[ \t]
D					[0-9]
L					[A-Z_a-z]


%%

/* Scanner body */

({D}*\.)?{D}+			{ Debug(); GetNumber();	return (int) Token.NUMBER; }
{D}+\.{D}*				{ Debug(); GetNumber();	return (int) Token.NUMBER; }

{D}+(\.{D}+)?".."		{ Debug("numWithDot: {0}", yytext); yyless(yytext.Length - 2); Debug(); GetNumber();	return (int) Token.NUMBER; }

true					{ Debug(); GetBool();	return (int) Token.BOOLEAN; }
false					{ Debug(); GetBool();	return (int) Token.BOOLEAN; }

\"[^\"\r\n]*\"			{ Debug(); GetString();	return (int) Token.STRING; }

not						{ Debug();		return (int) Token.NOT; }

{L}({L}|{D})*			{ Debug();		return (int) Token.NAME; }

\-						{ Debug();		return (int) Token.OP_MINUS; }
\+						{ Debug();		return (int) Token.OP_PLUS; }
\/						{ Debug();		return (int) Token.OP_DIV; }
\*\*					{ Debug();		return (int) Token.OP_POW; }
\*						{ Debug();		return (int) Token.OP_MUL; }

\(						{ Debug();		return (int) Token.P_OPEN; }
\)						{ Debug();		return (int) Token.P_CLOSE; }
\[						{ Debug();		return (int) Token.SP_OPEN; }
\]						{ Debug();		return (int) Token.SP_CLOSE; }

\=						{ Debug();		return (int) Token.C_EQ; }
\<=						{ Debug();		return (int) Token.C_LE; }
\<						{ Debug();		return (int) Token.C_LT; }
\>=						{ Debug();		return (int) Token.C_GE; }
\>						{ Debug();		return (int) Token.C_GT; }

\.						{ Debug();		return (int) Token.DOT; }
".."					{ Debug();		return (int) Token.RANGE; }
\,						{ Debug();		return (int) Token.COMMA; }

{S}+					/* skip */
.						{ UnexpectedCharacter(); }


%%

// The use code section.
// It is empty, because use code goes in a partial class.
