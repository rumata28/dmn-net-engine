%namespace Softengi.DmnEngine.SFeel.Parser
%scannertype SFeelScanner
%visibility internal
%tokentype Token

%option stack, minimize, parser, verbose, persistbuffer, noembedbuffers 

Eol						(\r\n?|\n)
NotWh					[^ \t\r\n]
Space					[ \t]
Digit					[0-9]
Digits					{Digit}+
Alpha					[A-Z_a-z]

%{

%}

%%

/* Scanner body */

[\-]{Digits}[[\.]{Digits}]	{ Debug();		GetNumber(); return (int) Token.NUMBER; }
[\-]\.{Digits}				{ Debug();		GetNumber(); return (int) Token.NUMBER; }

not							{ Debug();		return (int) Token.NOT; }

{Alpha}({Alpha}|{Digit})*	{ Debug();		return (int) Token.NAME; }


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

\.\.					{ Debug();		return (int) Token.RANGE; }
\.						{ Debug();		return (int) Token.DOT; }
\,						{ Debug();		return (int) Token.COMMA; }

{Space}+				/* skip */
.						{ throw new Exception("Unexpected character"); }


%%

// The use code section.
// It is empty, because use code goes in a partial class.