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
	| simpleUnaryTests		{ Debug("main");		Root = $1; }
	;

simpleUnaryTests:
	| simplePositiveUnaryTests								{ Debug("simpleUnaryTests");		$$ = $1;			}
	| NOT P_OPEN simplePositiveUnaryTests P_CLOSE			{ Debug("simpleUnaryTests/not");	$$ = new Not($3);	}
	;

simplePositiveUnaryTests:
	| simplePositiveUnaryTest									{ Debug("simplePositiveUnaryTests");	$$ = $1;						}
	| simplePositiveUnaryTests COMMA simplePositiveUnaryTest	{ Debug("simplePositiveUnaryTests/,");	$$ = new Or($1, $3);			}
	| OP_MINUS													{ Debug("simplePositiveUnaryTests/-");	$$ = new BooleanLiteral(true);	}
	;

simplePositiveUnaryTest:
	| endpoint											{ Debug("simplePositiveUnaryTest");		$$ = new Comparison(ComparisonOperator.Equal, new InputValue(), $1); }
	| simplePositiveUnaryTestOp endpoint				{ Debug("simplePositiveUnaryTest/cmp");	$$ = new Comparison($1, new InputValue(), $2); }
	| intervalStart endpoint RANGE endpoint intervalEnd	{ Debug("simplePositiveUnaryTest/rng");	$$ = new Range($1, $5, $2, $4, new InputValue()); }
	;

intervalStart:
	| closeIntervalStart	{ $$ = false; }
	| SP_OPEN				{ $$ = true;  }
	;

closeIntervalStart:
	| P_OPEN
	| SP_CLOSE
	;

intervalEnd:
	| closeIntervalEnd	{ $$ = false; }
	| SP_CLOSE			{ $$ = true;  }
	;

closeIntervalEnd:
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
	| simpleValue				{ Debug("endpoint/value"); $$ = $1; }
	;

simpleValue:
	| simpleLiteral				{ Debug("simpleLiteral/lit");	$$ = $1; }
	| qualifiedName				{ Debug("simpleLiteral/qn");	$$ = $1; }
	;

simpleLiteral:
	| numericLiteral			{ Debug("simpleLiteral/num");	$$ = $1; }
	| stringLiteral				{ Debug("simpleLiteral/str");	$$ = $1; }
	| booleanLiteral			{ Debug("simpleLiteral/bool");	$$ = $1; }
	;

numericLiteral:
	| NUMBER					{ Debug("numericLiteral"); $$ = new NumericLiteral($1); }
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
