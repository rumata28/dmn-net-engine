%namespace Softengi.DmnEngine.Parser
%namespace Softengi.DmnEngine.Parser
%scannertype FeelScanner
%visibility internal
%tokentype Token


%option stack, minimize, parser, verbose, persistbuffer, noembedbuffers 

%x LineComment
%x BlockComment

Eol					(\r\n?|\n)
NotWh				[^ \t\r\n]
S					[ \t]
D					[0-9]
L					[A-Z_a-z]


%%

/* Scanner body */

%{
if (StartToken != 0)
{
	int t = StartToken;
	StartToken = 0;
	return t;
}
%}

"//"						{ BEGIN(LineComment); }
<LineComment>Eol			{ BEGIN(INITIAL); }

"/*"						{ BEGIN(BlockComment); }
<BlockComment>"*/"			{ BEGIN(INITIAL); }

({D}*\.)?{D}+			{ Debug(); GetNumber();	return (int) Token.NUMBER; }
{D}+\.{D}*				{ Debug(); GetNumber();	return (int) Token.NUMBER; }

{D}+(\.{D}+)?".."		{ Debug("numWithDot: {0}", yytext); yyless(yytext.Length - 2); Debug(); GetNumber();	return (int) Token.NUMBER; }

null					{ Debug();		return (int) Token.NULL; }
true					{ Debug(); GetBool();	return (int) Token.BOOLEAN; }
false					{ Debug(); GetBool();	return (int) Token.BOOLEAN; }

\"[^\"\r\n]*\"			{ Debug(); GetString();	return (int) Token.STRING; }

not						{ Debug();		return (int) Token.NOT; }
or						{ Debug();		return (int) Token.OR; }
and						{ Debug();		return (int) Token.AND; }

for						{ Debug();		return (int) Token.FOR; }
return					{ Debug();		return (int) Token.RETURN; }
in						{ Debug();		return (int) Token.IN; }
if						{ Debug();		return (int) Token.IF; }
then					{ Debug();		return (int) Token.THEN; }
else					{ Debug();		return (int) Token.ELSE; }
some					{ Debug();		return (int) Token.SOME; }
every					{ Debug();		return (int) Token.EVERY; }
satisfies				{ Debug();		return (int) Token.SATISFIES; }
instance				{ Debug();		return (int) Token.INSTANCE; }
of						{ Debug();		return (int) Token.OF; }
function				{ Debug();		return (int) Token.FUNCTION; }
external				{ Debug();		return (int) Token.EXTERNAL; }


date					{ Debug();		return (int) Token.DATE; }
time					{ Debug();		return (int) Token.TIME; }
duration				{ Debug();		return (int) Token.DURATION; }

// 27-32 - simplified, no support for unicode yet
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
\{						{ Debug();		return (int) Token.CP_OPEN; }
\}						{ Debug();		return (int) Token.CP_CLOSE; }

\=						{ Debug();		return (int) Token.C_EQ; }
\!=						{ Debug();		return (int) Token.C_NE; }
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
