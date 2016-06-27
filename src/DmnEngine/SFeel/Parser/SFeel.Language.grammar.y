%namespace Softengi.DmnEngine.SFeel.Parser
%partial
%parsertype SFeelParser
%visibility internal
%tokentype Token
%using Softengi.DmnEngine.SFeel.Ast

%union { 
			public decimal n; 
			public string s; 
			public bool b;

			public INode nd;
			public QualifiedName qn;
			public ILogical lg;

			public ComparisonOperator co;
	   }

%start main

%token <s> STRING, NAME
%token <n> NUMBER
%token <b> BOOLEAN

%token	C_EQ, C_LT, C_LE, C_GT, C_GE,
		OP_MINUS, OP_PLUS, OP_DIV, OP_MUL, OP_POW,
		P_OPEN, P_CLOSE,
		SP_OPEN, SP_CLOSE,
		COMMA, DOT, RANGE,
		NOT

%type <lg>	simpleUnaryTests, simplePositiveUnaryTests, simplePositiveUnaryTest
%type <nd>	endpoint, simpleValue, simpleLiteral, numericLiteral, booleanLiteral, stringLiteral
%type <co>	simplePositiveUnaryTestOp
%type <b>	intervalStart, intervalEnd
%type <qn>	qualifiedName


%%

main:
	| simpleUnaryTests		{ Root = $1; }
	;

simpleUnaryTests:
	| simplePositiveUnaryTests								{ $$ = $1;			}
	| NOT P_OPEN simplePositiveUnaryTests P_CLOSE			{ $$ = new Not($3);	}
	;

simplePositiveUnaryTests:
	| simplePositiveUnaryTest									{ $$ = $1;							}
	| simplePositiveUnaryTests COMMA simplePositiveUnaryTest	{ $$ = new Or($1, $3);				}
	| OP_MINUS													{ $$ = new BooleanLiteral(true);	}
	;

simplePositiveUnaryTest:
	| simplePositiveUnaryTestOp endpoint				{ $$ = new Comparison($1, $2, new InputValue()); }
	| intervalStart endpoint RANGE endpoint intervalEnd	{ $$ = new Range($1, $5, $2, $4, new InputValue()); }
	;

intervalStart:
	| openIntervalStart	{ $$ = true; }
	| SP_OPEN			{ $$ = false; }
	;

openIntervalStart:
	| P_OPEN
	| SP_CLOSE
	;

intervalEnd:
	| openIntervalEnd	{ $$ = true; }
	| SP_CLOSE			{ $$ = false; }
	;

openIntervalEnd:
	| P_CLOSE
	| SP_OPEN
	;

simplePositiveUnaryTestOp:
	| C_LT		{ $$ = ComparisonOperator.LessThan;			  }
	| C_LE		{ $$ = ComparisonOperator.LessThanOrEqual;	  }
	| C_GT		{ $$ = ComparisonOperator.GreaterThan;		  }
	| C_GE		{ $$ = ComparisonOperator.GreaterThanOrEqual; }
	;

endpoint:
	| simpleValue				{ $$ = $1; }
	;

simpleValue:
	| simpleLiteral				{ $$ = $1; }
	| qualifiedName				{ $$ = $1; }
	;

simpleLiteral:
	| numericLiteral			{ $$ = $1; }
	| stringLiteral				{ $$ = $1; }
	| booleanLiteral			{ $$ = $1; }
	;

numericLiteral:
	| NUMBER					{ $$ = new NumericLiteral($1); }
	;

stringLiteral:
	| STRING					{ $$ = new StringLiteral($1); }
	;

booleanLiteral:
	| BOOLEAN					{ $$ = new BooleanLiteral($1); }
	;

qualifiedName:
	| NAME						{ $$ = new QualifiedName($1);		}
	| qualifiedName DOT NAME	{ $$ = $1;	$$.AddComponent($3);	}
	;

%%

// The use code section.
// It is empty, because use code goes in a partial class.
