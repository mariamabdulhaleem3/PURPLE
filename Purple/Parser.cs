
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF          =  0, // (EOF)
        SYMBOL_ERROR        =  1, // (Error)
        SYMBOL_WHITESPACE   =  2, // Whitespace
        SYMBOL_MINUS        =  3, // '-'
        SYMBOL_EXCLAMEQ     =  4, // '!='
        SYMBOL_PERCENT      =  5, // '%'
        SYMBOL_LPAREN       =  6, // '('
        SYMBOL_RPAREN       =  7, // ')'
        SYMBOL_TIMES        =  8, // '*'
        SYMBOL_COMMA        =  9, // ','
        SYMBOL_DIV          = 10, // '/'
        SYMBOL_LBRACE       = 11, // '{'
        SYMBOL_RBRACE       = 12, // '}'
        SYMBOL_RBRACE2      = 13, // '} '
        SYMBOL_PLUS         = 14, // '+'
        SYMBOL_PLUSPLUS     = 15, // '++'
        SYMBOL_LT           = 16, // '<'
        SYMBOL_LTEQ         = 17, // '<='
        SYMBOL_EQ           = 18, // '='
        SYMBOL_EQEQ         = 19, // '=='
        SYMBOL_GT           = 20, // '>'
        SYMBOL_GTEQ         = 21, // '>='
        SYMBOL_AS           = 22, // As
        SYMBOL_BYE          = 23, // Bye
        SYMBOL_DIGIT        = 24, // Digit
        SYMBOL_DO           = 25, // Do
        SYMBOL_FUNCTION     = 26, // function
        SYMBOL_HAPPENED     = 27, // happened
        SYMBOL_HI           = 28, // Hi
        SYMBOL_ID           = 29, // Id
        SYMBOL_IF           = 30, // If
        SYMBOL_IN           = 31, // in
        SYMBOL_LONG         = 32, // long
        SYMBOL_OTHERWISE    = 33, // Otherwise
        SYMBOL_PURPLE       = 34, // Purple
        SYMBOL_STORE        = 35, // Store
        SYMBOL_UNTIL        = 36, // until
        SYMBOL_ASLONGAS     = 37, // <As long as>
        SYMBOL_ASSIGN       = 38, // <Assign>
        SYMBOL_BLOCK        = 39, // <Block>
        SYMBOL_CALLING      = 40, // <calling>
        SYMBOL_DECMINUSFUNC = 41, // <dec-func>
        SYMBOL_DOUNTIL      = 42, // <doUntil>
        SYMBOL_EXPR         = 43, // <Expr>
        SYMBOL_FACTOR       = 44, // <Factor>
        SYMBOL_FUNCNAME     = 45, // <funcName>
        SYMBOL_FUNCTION2    = 46, // <Function>
        SYMBOL_ID2          = 47, // <Id>
        SYMBOL_IF2          = 48, // <If>
        SYMBOL_OP           = 49, // <Op>
        SYMBOL_PARAMETER    = 50, // <parameter>
        SYMBOL_PURPLE2      = 51, // <Purple>
        SYMBOL_STATEMENTS   = 52, // <Statements>
        SYMBOL_TERM         = 53  // <Term>
    };

    enum RuleConstants : int
    {
        RULE_PURPLE_HI_PURPLE_LBRACE_RBRACE_BYE_PURPLE                                   =  0, // <Purple> ::= Hi Purple '{' <Statements> '}' Bye Purple
        RULE_STATEMENTS                                                                  =  1, // <Statements> ::= <Block>
        RULE_STATEMENTS2                                                                 =  2, // <Statements> ::= <Block> <Statements>
        RULE_BLOCK                                                                       =  3, // <Block> ::= <Assign>
        RULE_BLOCK2                                                                      =  4, // <Block> ::= <If>
        RULE_BLOCK3                                                                      =  5, // <Block> ::= <As long as>
        RULE_BLOCK4                                                                      =  6, // <Block> ::= <doUntil>
        RULE_BLOCK5                                                                      =  7, // <Block> ::= <calling>
        RULE_DECFUNC                                                                     =  8, // <dec-func> ::= <Function>
        RULE_DECFUNC2                                                                    =  9, // <dec-func> ::= <Function> <dec-func>
        RULE_ASSIGN_STORE_IN                                                             = 10, // <Assign> ::= Store <Expr> in <Id>
        RULE_ID_ID                                                                       = 11, // <Id> ::= Id
        RULE_EXPR_PLUS                                                                   = 12, // <Expr> ::= <Expr> '+' <Term>
        RULE_EXPR_MINUS                                                                  = 13, // <Expr> ::= <Expr> '-' <Term>
        RULE_EXPR                                                                        = 14, // <Expr> ::= <Term>
        RULE_TERM_TIMES                                                                  = 15, // <Term> ::= <Term> '*' <Factor>
        RULE_TERM_DIV                                                                    = 16, // <Term> ::= <Term> '/' <Factor>
        RULE_TERM_PERCENT                                                                = 17, // <Term> ::= <Term> '%' <Factor>
        RULE_TERM                                                                        = 18, // <Term> ::= <Factor>
        RULE_FACTOR_DIGIT                                                                = 19, // <Factor> ::= Digit
        RULE_IF_IF_LPAREN_RPAREN_HAPPENED_COMMA_DO_LBRACE_RBRACE_OTHERWISE_LBRACE_RBRACE = 20, // <If> ::= If '(' <Id> <Op> <Expr> ')' happened ',' Do '{' <Statements> '} ' Otherwise '{' <Statements> '}'
        RULE_OP_LT                                                                       = 21, // <Op> ::= '<'
        RULE_OP_LTEQ                                                                     = 22, // <Op> ::= '<='
        RULE_OP_GT                                                                       = 23, // <Op> ::= '>'
        RULE_OP_GTEQ                                                                     = 24, // <Op> ::= '>='
        RULE_OP_EQEQ                                                                     = 25, // <Op> ::= '=='
        RULE_OP_EXCLAMEQ                                                                 = 26, // <Op> ::= '!='
        RULE_ASLONGAS_EQ_DIGIT_AS_LONG_AS_LPAREN_RPAREN_DO_LBRACE_PLUSPLUS_RBRACE        = 27, // <As long as> ::= <Id> '=' Digit As long As '(' <Id> <Op> <Expr> ')' Do '{' <Statements> <Id> '++' '}'
        RULE_DOUNTIL_DO_LBRACE_RBRACE_UNTIL_LPAREN_RPAREN                                = 28, // <doUntil> ::= Do '{' <Statements> '}' until '(' <Id> <Op> <Expr> ')'
        RULE_FUNCTION_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE                               = 29, // <Function> ::= function <funcName> '(' <Id> ')' '{' <Statements> '}'
        RULE_FUNCNAME_ID                                                                 = 30, // <funcName> ::= Id
        RULE_CALLING_LPAREN_RPAREN                                                       = 31, // <calling> ::= <funcName> '(' <parameter> ')'
        RULE_PARAMETER_ID                                                                = 32, // <parameter> ::= Id
        RULE_PARAMETER_DIGIT                                                             = 33  // <parameter> ::= Digit
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE2 :
                //'} '
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AS :
                //As
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BYE :
                //Bye
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //Do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HAPPENED :
                //happened
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HI :
                //Hi
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //If
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LONG :
                //long
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OTHERWISE :
                //Otherwise
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PURPLE :
                //Purple
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STORE :
                //Store
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNTIL :
                //until
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASLONGAS :
                //<As long as>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<Assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<Block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CALLING :
                //<calling>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECMINUSFUNC :
                //<dec-func>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUNTIL :
                //<doUntil>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<Expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCNAME :
                //<funcName>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION2 :
                //<Function>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<Id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF2 :
                //<If>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<Op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER :
                //<parameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PURPLE2 :
                //<Purple>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTS :
                //<Statements>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<Term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PURPLE_HI_PURPLE_LBRACE_RBRACE_BYE_PURPLE :
                //<Purple> ::= Hi Purple '{' <Statements> '}' Bye Purple
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTS :
                //<Statements> ::= <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTS2 :
                //<Statements> ::= <Block> <Statements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK :
                //<Block> ::= <Assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK2 :
                //<Block> ::= <If>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK3 :
                //<Block> ::= <As long as>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK4 :
                //<Block> ::= <doUntil>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK5 :
                //<Block> ::= <calling>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECFUNC :
                //<dec-func> ::= <Function>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECFUNC2 :
                //<dec-func> ::= <Function> <dec-func>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_STORE_IN :
                //<Assign> ::= Store <Expr> in <Id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<Id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<Expr> ::= <Expr> '+' <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<Expr> ::= <Expr> '-' <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<Expr> ::= <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<Term> ::= <Term> '*' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<Term> ::= <Term> '/' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<Term> ::= <Term> '%' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<Term> ::= <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_DIGIT :
                //<Factor> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IF_LPAREN_RPAREN_HAPPENED_COMMA_DO_LBRACE_RBRACE_OTHERWISE_LBRACE_RBRACE :
                //<If> ::= If '(' <Id> <Op> <Expr> ')' happened ',' Do '{' <Statements> '} ' Otherwise '{' <Statements> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<Op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<Op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<Op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<Op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<Op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<Op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASLONGAS_EQ_DIGIT_AS_LONG_AS_LPAREN_RPAREN_DO_LBRACE_PLUSPLUS_RBRACE :
                //<As long as> ::= <Id> '=' Digit As long As '(' <Id> <Op> <Expr> ')' Do '{' <Statements> <Id> '++' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DOUNTIL_DO_LBRACE_RBRACE_UNTIL_LPAREN_RPAREN :
                //<doUntil> ::= Do '{' <Statements> '}' until '(' <Id> <Op> <Expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Function> ::= function <funcName> '(' <Id> ')' '{' <Statements> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCNAME_ID :
                //<funcName> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CALLING_LPAREN_RPAREN :
                //<calling> ::= <funcName> '(' <parameter> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_ID :
                //<parameter> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_DIGIT :
                //<parameter> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
