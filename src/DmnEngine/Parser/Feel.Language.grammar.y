%namespace Softengi.DmnEngine.Parser
%partial
%parsertype FeelParser
%visibility internal
%tokentype Token
%using Softengi.DmnEngine.Ast

%union { 
			public decimal n; 
			public string s; 
			public bool b;
			public QualifiedName qn;

			public INode nd;
			public IExpression ex;
			public ILogical lg;

			public ComparisonOperator co;
			public QuantorOperator qo;

			public ExpressionList el;
	   }

%token <s> STRING, NAME
%token <n> NUMBER
%token <b> BOOLEAN

%token	C_EQ, C_NE, C_LT, C_LE, C_GT, C_GE,
		OP_MINUS, OP_PLUS, OP_DIV, OP_MUL, OP_POW,
		P_OPEN, P_CLOSE,
		SP_OPEN, SP_CLOSE,
		CP_OPEN, CP_CLOSE,
		COMMA, DOT, COLON, RANGE,
		NULL,
		NOT, OR, AND,
		IN, BETWEEN,
		FOR, RETURN,
		IF, THEN, ELSE,
		SOME, EVERY, SATISFIES,
		INSTANCE, OF,
		FUNCTION, EXTERNAL,
		DATE, TIME, DURATION

%type <nd>	endpoint, literal, simpleValue, simpleLiteral, numericLiteral, booleanLiteral, stringLiteral, dateTimeLiteral,
			functionInvocation
%type <ex>	expression, textualExpression, boxedExpression, functionDefinition, forExpression, ifExpression, quantifiedExpression,
			disjunction, conjunction, arithmeticExpression, pathExpression, filterExpression
%type <lg>	unaryTests		, positiveUnaryTests	  , positiveUnaryTest	   ,
			simpleUnaryTests, simplePositiveUnaryTests, simplePositiveUnaryTest, 
			instanceOf, comparison
%type <el>	simpleExpressions

%type <co>	simplePositiveUnaryTestOp, comparisonOp
%type <qo>	quantorOp
%type <b>	intervalStart, intervalEnd
%type <qn>	qualifiedName


%token UNARY_START
%token EXPRESSION_START
/* this is to allow to start from different rules each time
*/

%start main


%%

main: UNARY_START simpleUnaryTests		{ Debug("main/unary");		Root = $1; }
	| EXPRESSION_START expression		{ Debug("main/expression");	Root = $1; }
	;

// 1
expression:
	  textualExpression					{ Debug("expression/text");	$$ = $1; }
	| boxedExpression					{ Debug("expression/box");	$$ = $1; }
	;

// 2
textualExpression:
	  functionDefinition				{ Debug("textualExpression/funDef");	$$ = $1; }
	| forExpression						{ Debug("textualExpression/for");		$$ = $1; }
	| ifExpression						{ Debug("textualExpression/if");		$$ = $1; }
	| quantifiedExpression				{ Debug("textualExpression/quan");		$$ = $1; }
	| disjunction						{ Debug("textualExpression/disj");		$$ = $1; }
	| conjunction						{ Debug("textualExpression/conj");		$$ = $1; }
	| comparison						{ Debug("textualExpression/comp");		$$ = $1; }
	| arithmeticExpression				{ Debug("textualExpression/arith");		$$ = $1; }
	| instanceOf						{ Debug("textualExpression/inst");		$$ = $1; }
	| pathExpression					{ Debug("textualExpression/path");		$$ = $1; }
	| filterExpression					{ Debug("textualExpression/filt");		$$ = $1; }
	| functionInvocation				{ Debug("textualExpression/funInv");	$$ = $1; }
	| literal							{ Debug("textualExpression/lit");		$$ = $1; }
	| simplePositiveUnaryTest			{ Debug("textualExpression/spUT");		$$ = $1; }
	| NAME								{ Debug("textualExpression/name");		$$ = $1; }
	| P_OPEN textualExpression P_CLOSE	{ Debug("textualExpression/braces");	$$ = $2; }
	;

// 3
textualExpressions:			   textualExpression	{ Debug("textualExpressions");	 $$ = $1;			  }
	| textualExpressions COMMA textualExpression	{ Debug("textualExpressions/,"); $$ = new Or($1, $3); }
	;

// 4
arithmeticExpression:
	  addition					{ Debug("arithmeticExpression/add"); $$ = $1; }
	| subtraction				{ Debug("arithmeticExpression/sub"); $$ = $1; }
	| multiplication			{ Debug("arithmeticExpression/mul"); $$ = $1; }
	| division					{ Debug("arithmeticExpression/div"); $$ = $1; }
	| exponentiation			{ Debug("arithmeticExpression/pow"); $$ = $1; }
	| arithmeticNegation		{ Debug("arithmeticExpression/neg"); $$ = $1; }
	;

// 5
simpleExpression:
	  arithmeticExpression		{ Debug("simpleExpression/arith");	$$ = $1; }
	| simpleValue				{ Debug("simpleExpression/simVal");	$$ = $1; }
	;

// 6
simpleExpressions:
	  simpleExpression								{ Debug("simpleExpressions");	$$ = new ExpressionList(); $$.Add($1); }
	| simpleExpressions COMMA simpleExpression		{ Debug("simpleExpressions/,"); $$ = $1;				   $$.Add($3); }
	;

// 7, 8
simplePositiveUnaryTest:
	  endpoint												{ Debug("simplePositiveUnaryTest");		$$ = new Comparison(ComparisonOperator.Equal, new InputValue(), $1); }
	| simplePositiveUnaryTestOp endpoint					{ Debug("simplePositiveUnaryTest/cmp");	$$ = new Comparison($1, new InputValue(), $2);						 }
	| intervalStart endpoint RANGE endpoint intervalEnd		{ Debug("simplePositiveUnaryTest/rng");	$$ = new Range($1, $5, $2, $4, new InputValue());					 }
	;

// 8
simplePositiveUnaryTestOp:
	  C_LT		{ $$ = ComparisonOperator.LessThan;			  }
	| C_LE		{ $$ = ComparisonOperator.LessThanOrEqual;	  }
	| C_GT		{ $$ = ComparisonOperator.GreaterThan;		  }
	| C_GE		{ $$ = ComparisonOperator.GreaterThanOrEqual; }
	;

// 9, 10
intervalStart:
	  closedIntervalStart	{ $$ = false; }
	| SP_OPEN				{ $$ = true;  }
	;

// 10
closedIntervalStart: P_OPEN	| SP_CLOSE;

// 11, 12
intervalEnd:
	  closedIntervalEnd	{ $$ = false; }
	| SP_CLOSE			{ $$ = true;  }
	;

// 12
closedIntervalEnd: P_CLOSE | SP_OPEN;

// 13
simplePositiveUnaryTests:
	  simplePositiveUnaryTest									{ Debug("simplePositiveUnaryTests");	$$ = $1;			 }
	| simplePositiveUnaryTests COMMA simplePositiveUnaryTest	{ Debug("simplePositiveUnaryTests/,");	$$ = new Or($1, $3); }
	;

// 14
simpleUnaryTests:
	  simplePositiveUnaryTests								{ Debug("simpleUnaryTests");		$$ = $1;						}
	| NOT P_OPEN simplePositiveUnaryTests P_CLOSE			{ Debug("simpleUnaryTests/not");	$$ = new Not($3);				}
	| OP_MINUS												{ Debug("simpleUnaryTests/-");		$$ = new BooleanLiteral(true);	}
	;

// 15
positiveUnaryTest:
      simplePositiveUnaryTest
	| NULL
	;

// 16
positiveUnaryTests:
	  positiveUnaryTest								{ Debug("positiveUnaryTests");	 $$ = $1;			  }
	| positiveUnaryTests COMMA positiveUnaryTest	{ Debug("positiveUnaryTests/,"); $$ = new Or($1, $3); }
	;

// 17
unaryTests:
	  positiveUnaryTests							{ Debug("unaryTests");		$$ = $1;					   }
	| NOT P_OPEN positiveUnaryTests P_CLOSE			{ Debug("unaryTests/not");	$$ = new Not($3);			   }
	| OP_MINUS										{ Debug("unaryTests/-");	$$ = new BooleanLiteral(true); }
	;

// 18
endpoint: simpleValue { Debug("endpoint/value"); $$ = $1; };

// 19
simpleValue:
	  simpleLiteral				{ Debug("simpleValue/lit");	$$ = $1; }
	| qualifiedName				{ Debug("simpleValue/qn");	$$ = $1; }
	;

// 20
qualifiedName:			NAME	{ $$ = new QualifiedName($1);		}
	| qualifiedName DOT NAME	{ $$ = $1;	$$.AddComponent($3);	}
	;

// 21-25
addition      : expression OP_PLUS  expression	{ Debug("add"); $$ = new Add($1, $3); };
subtraction   : expression OP_MINUS expression	{ Debug("sub"); $$ = new Sub($1, $3); };
multiplication: expression OP_MUL   expression	{ Debug("mul"); $$ = new Mul($1, $3); };
division	  :	expression OP_DIV   expression	{ Debug("div"); $$ = new Div($1, $3); };
exponentiation: expression OP_POW   expression	{ Debug("pow"); $$ = new Pow($1, $3); };

// 26
arithmeticNegation: OP_MINUS expression			{ Debug("neg"); $$ = new Neg($2); };

// 33
literal:
	  simpleLiteral	{ Debug("literal/simLit");	$$ = $1; }
	| NULL		    { Debug("literal/null");	$$ = $1; }
	;

// 34
simpleLiteral:
	  numericLiteral	{ Debug("simpleLiteral/num");	$$ = $1; }
	| stringLiteral		{ Debug("simpleLiteral/str");	$$ = $1; }
	| booleanLiteral	{ Debug("simpleLiteral/bool");	$$ = $1; }
	| dateTimeLiteral	{ Debug("simpleLiteral/dt");	$$ = $1; }
	;

// 35
stringLiteral : STRING	{ $$ = new StringLiteral($1); }	;

// 36
booleanLiteral: BOOLEAN	{ $$ = new BooleanLiteral($1); };

// 37-39
numericLiteral:
			   NUMBER	{ Debug("numericLiteral");     $$ = new NumericLiteral( $1); }
	| OP_MINUS NUMBER	{ Debug("numericLiteral/neg"); $$ = new NumericLiteral(-$2); }
	;

// 40
functionInvocation: expression parameters	{ Debug("functionInvocation");	$$ = new FunctionInvocation($1, $2); };

// 41
parameters:
	  P_OPEN namedParameters P_CLOSE	{ Debug("parameters/named");	$$ = $1; }
	| P_OPEN expressionList P_CLOSE		{ Debug("parameters/pos");		$$ = $1; }
	;

// 42
namedParameters:			namedParameter	{ Debug("namedParameters");	  $$ = new NamedParameterList($1); }
	| namedParameters COMMA namedParameter	{ Debug("namedParameters/,"); $$ = $1; $$.Add($3);			   }
	;

// 42
namedParameter:	NAME COLON expression		{ Debug("namedParameter");	  $$ = new NamedParam($1, $3); };

// 45
pathExpression: expression DOT NAME		{ Debug("pathExpression"); $$ = new PathExpression($1, $3); };

// 46
forExpression: FOR inParts RETURN expression		{ Debug("forExpression");  $$ = new For($2, $4); };

// 47
ifExpression: IF expression THEN expression ELSE expression			{ Debug("ifExpression");  $$ = new If($2, $4, $6); };

// 48
quantifiedExpression: quantorOp NAME IN inParts SATISFIES expression		{ Debug("quantifiedExpression");  $$ = new QuantifiedExpression($1, $4, $6); };

// 49
quantorOp:
	  SOME		{ $$ = QuantorOperator.Some;  }
	| EVERY		{ $$ = QuantorOperator.Every; }
	;

// 46,48
inParts:
	  inPart					{ Debug("inParts");   $$ = new InPartList($1); }
	| inParts COMMA inPart		{ Debug("inParts/,"); $$ = $1; $$.Add($3);	   }
	;

// 46,48:
inPart: NAME IN expression		{ Debug("inPart");   $$ = new InPart($1, $3); };

// 49-50
disjunction: expression OR expression	{ Debug("disjunction");  $$ = new Or($1, $3); };
conjunction: expression AND expression	{ Debug("conjunction");  $$ = new And($1, $3); };

// 51
comparison:	  expression comparisonOp expression				{ Debug("comparision/cmp");	 $$ = new Comparison($2, $1, $3);		 }
			| expression BETWEEN expression AND expression		{ Debug("comparision/btw");	 $$ = new Range(true, true, $3, $5, $1); }
			| expression IN positiveUnaryTests					{ Debug("comparision/in");	 $$ = new In($1, $3);					 }
			| expression IN P_OPEN positiveUnaryTests P_CLOSE	{ Debug("comparision/P_in"); $$ = new In($1, $4);					 }
			;

// 51
comparisonOp:
	  C_NE	{ $$ = ComparisonOperator.NotEqual;			  }
	| C_EQ	{ $$ = ComparisonOperator.Equal;			  }
	| C_LT	{ $$ = ComparisonOperator.LessThan;			  }
	| C_LE	{ $$ = ComparisonOperator.LessThanOrEqual;	  }
	| C_GT	{ $$ = ComparisonOperator.GreaterThan;		  }
	| C_GE	{ $$ = ComparisonOperator.GreaterThanOrEqual; }
	;

// 52
filterExpression: expression SP_OPEN expression SP_CLOSE	{ Debug("filterExpression"); $$ = new Filter($1, $3); };

// 53,54
instanceOf: expression INSTANCE OF qualifiedName	{ Debug("instanceOf"); $$ = new InstanceOf($1, $4); };

// 55, 56, 59
boxedExpression:
	  SP_OPEN expressionList SP_CLOSE		{ Debug("boxedExpression/list");	$$ = $2; }
	| CP_OPEN contextEntries CP_CLOSE		{ Debug("boxedExpression/context"); $$ = $2; }
	| functionDefinition					{ Debug("boxedExpression/funDef");  $$ = $1; }
	;

// 44, 56
expressionList:			   expression		{ Debug("expressionList");   $$ = new ExpressionList($1); }
	| expressionList COMMA expression		{ Debug("expressionList/,"); $$ = $1;		  $$.Add($3); }
	;

// 57
functionDefinition:
	  FUNCTION P_OPEN nameList P_CLOSE			expression
	| FUNCTION P_OPEN nameList P_CLOSE EXTERNAL expression
	;

// 57
nameList:			 NAME	{ Debug("formatParameterList");   $$ = new nameList($1); }
	| nameList COMMA NAME	{ Debug("formatParameterList/,"); $$ = $1; $$.Add($3);	 }
	;

// 59
contextEntries:			   contextEntry		{ Debug("contextEntries/,"); $$ = new ContextEntryList($1); }
	| contextEntries COMMA contextEntry		{ Debug("contextEntries/,"); $$ = $1; $$.Add($3);			}
	;

// 60
contextEntry: key COLON expression			{ Debug("contextEntry");	$$ = new KeyValue($1, $3); };

// 61
key:  NAME				{ Debug("key/name");	$$ = $1; }
	| stringLiteral		{ Debug("key/strLit");	$$ = $1; }
	;

// 62
dateTimeLiteral:
	  DATE P_OPEN stringLiteral P_CLOSE				{ $$ = DateTimeLiteral.ParseDate(((StringLiteral) $3).Value);		 }
	| TIME P_OPEN stringLiteral P_CLOSE				{ $$ = DateTimeLiteral.ParseTime(((StringLiteral) $3).Value);		 }
	| DATE AND TIME P_OPEN stringLiteral P_CLOSE	{ $$ = DateTimeLiteral.ParseDateAndTime(((StringLiteral) $5).Value); }
	| DURATION P_OPEN stringLiteral P_CLOSE			{ $$ = TimeSpanLiteral.Parse(((StringLiteral) $3).Value);			 }
	;

%%

// The use code section.
// It is empty, because use code goes in a partial class.
