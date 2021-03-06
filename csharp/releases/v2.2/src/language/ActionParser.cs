// $ANTLR 2.7.5 (20050128): "action.g" -> "ActionParser.cs"$

/*
 [The "BSD licence"]
 Copyright (c) 2003-2004 Terence Parr
 All rights reserved.

 Redistribution and use in source and binary forms, with or without
 modification, are permitted provided that the following conditions
 are met:
 1. Redistributions of source code must retain the above copyright
    notice, this list of conditions and the following disclaimer.
 2. Redistributions in binary form must reproduce the above copyright
    notice, this list of conditions and the following disclaimer in the
    documentation and/or other materials provided with the distribution.
 3. The name of the author may not be used to endorse or promote products
    derived from this software without specific prior written permission.

 THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System.Collections;

namespace antlr.stringtemplate.language
{
	// Generate the header common to all output files.
	using System;
	
	using TokenBuffer              = antlr.TokenBuffer;
	using TokenStreamException     = antlr.TokenStreamException;
	using TokenStreamIOException   = antlr.TokenStreamIOException;
	using ANTLRException           = antlr.ANTLRException;
	using LLkParser = antlr.LLkParser;
	using Token                    = antlr.Token;
	using IToken                   = antlr.IToken;
	using TokenStream              = antlr.TokenStream;
	using RecognitionException     = antlr.RecognitionException;
	using NoViableAltException     = antlr.NoViableAltException;
	using MismatchedTokenException = antlr.MismatchedTokenException;
	using SemanticException        = antlr.SemanticException;
	using ParserSharedInputState   = antlr.ParserSharedInputState;
	using BitSet                   = antlr.collections.impl.BitSet;
	using AST                      = antlr.collections.AST;
	using ASTPair                  = antlr.ASTPair;
	using ASTFactory               = antlr.ASTFactory;
	using ASTArray                 = antlr.collections.impl.ASTArray;
	
/** Parse the individual attribute expressions */
	public 	class ActionParser : antlr.LLkParser
	{
		public const int EOF = 1;
		public const int NULL_TREE_LOOKAHEAD = 3;
		public const int APPLY = 4;
		public const int MULTI_APPLY = 5;
		public const int ARGS = 6;
		public const int INCLUDE = 7;
		public const int CONDITIONAL = 8;
		public const int VALUE = 9;
		public const int TEMPLATE = 10;
		public const int FUNCTION = 11;
		public const int SINGLEVALUEARG = 12;
		public const int LIST = 13;
		public const int SEMI = 14;
		public const int LPAREN = 15;
		public const int RPAREN = 16;
		public const int LITERAL_separator = 17;
		public const int ASSIGN = 18;
		public const int COLON = 19;
		public const int COMMA = 20;
		public const int NOT = 21;
		public const int PLUS = 22;
		public const int DOT = 23;
		public const int ID = 24;
		public const int LITERAL_first = 25;
		public const int LITERAL_rest = 26;
		public const int LITERAL_last = 27;
		public const int LITERAL_super = 28;
		public const int ANONYMOUS_TEMPLATE = 29;
		public const int STRING = 30;
		public const int INT = 31;
		public const int LBRACK = 32;
		public const int RBRACK = 33;
		public const int DOTDOTDOT = 34;
		public const int TEMPLATE_ARGS = 35;
		public const int NESTED_ANONYMOUS_TEMPLATE = 36;
		public const int ESC_CHAR = 37;
		public const int WS = 38;
		public const int WS_CHAR = 39;
		
		
    protected StringTemplate self = null;

    public ActionParser(TokenStream lexer, StringTemplate self) : this(lexer, 2) {        
        this.self = self;
    }

	override public void reportError(RecognitionException e) {
		self.error("template parse error", e);
	}
		
		protected void initialize()
		{
			tokenNames = tokenNames_;
			initializeFactory();
		}
		
		
		protected ActionParser(TokenBuffer tokenBuf, int k) : base(tokenBuf, k)
		{
			initialize();
		}
		
		public ActionParser(TokenBuffer tokenBuf) : this(tokenBuf,2)
		{
		}
		
		protected ActionParser(TokenStream lexer, int k) : base(lexer,k)
		{
			initialize();
		}
		
		public ActionParser(TokenStream lexer) : this(lexer,2)
		{
		}
		
		public ActionParser(ParserSharedInputState state) : base(state,2)
		{
			initialize();
		}
		
	public IDictionary  action() //throws RecognitionException, TokenStreamException
{
		IDictionary opts=null;
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST action_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LPAREN:
			case ID:
			case LITERAL_first:
			case LITERAL_rest:
			case LITERAL_last:
			case LITERAL_super:
			case ANONYMOUS_TEMPLATE:
			case STRING:
			case INT:
			case LBRACK:
			{
				templatesExpr();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				{
					switch ( LA(1) )
					{
					case SEMI:
					{
						match(SEMI);
						opts=optionList();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(currentAST, (AST)returnAST);
						}
						break;
					}
					case EOF:
					{
						break;
					}
					default:
					{
						throw new NoViableAltException(LT(1), getFilename());
					}
					 }
				}
				action_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			case CONDITIONAL:
			{
				antlr.stringtemplate.language.StringTemplateAST tmp2_AST = null;
				tmp2_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
				astFactory.makeASTRoot(currentAST, (AST)tmp2_AST);
				match(CONDITIONAL);
				match(LPAREN);
				ifCondition();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				match(RPAREN);
				action_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_0_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = action_AST;
		return opts;
		ASTPair.PutInstance(currentAST);
	}
	
	public void templatesExpr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST templatesExpr_AST = null;
		IToken  c = null;
		antlr.stringtemplate.language.StringTemplateAST c_AST = null;
		
		try {      // for error handling
			bool synPredMatched6 = false;
			if (((tokenSet_1_.member(LA(1))) && (tokenSet_2_.member(LA(2)))))
			{
				int _m6 = mark();
				synPredMatched6 = true;
				inputState.guessing++;
				try {
					{
						parallelArrayTemplateApplication();
					}
				}
				catch (RecognitionException)
				{
					synPredMatched6 = false;
				}
				rewind(_m6);
				inputState.guessing--;
			}
			if ( synPredMatched6 )
			{
				parallelArrayTemplateApplication();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				templatesExpr_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
			}
			else if ((tokenSet_1_.member(LA(1))) && (tokenSet_3_.member(LA(2)))) {
				expr();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				{    // ( ... )*
					for (;;)
					{
						if ((LA(1)==COLON))
						{
							c = LT(1);
							c_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(c);
							astFactory.makeASTRoot(currentAST, (AST)c_AST);
							match(COLON);
							if (0==inputState.guessing)
							{
								c_AST.setType(APPLY);
							}
							template();
							if (0 == inputState.guessing)
							{
								astFactory.addASTChild(currentAST, (AST)returnAST);
							}
							{    // ( ... )*
								for (;;)
								{
									if ((LA(1)==COMMA))
									{
										match(COMMA);
										template();
										if (0 == inputState.guessing)
										{
											astFactory.addASTChild(currentAST, (AST)returnAST);
										}
									}
									else
									{
										goto _loop9_breakloop;
									}
									
								}
_loop9_breakloop:								;
							}    // ( ... )*
						}
						else
						{
							goto _loop10_breakloop;
						}
						
					}
_loop10_breakloop:					;
				}    // ( ... )*
				templatesExpr_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
			}
			else
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = templatesExpr_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public IDictionary  optionList() //throws RecognitionException, TokenStreamException
{
		IDictionary opts=new Hashtable();
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST optionList_AST = null;
		antlr.stringtemplate.language.StringTemplateAST e_AST = null;
		
		try {      // for error handling
			match(LITERAL_separator);
			antlr.stringtemplate.language.StringTemplateAST tmp7_AST = null;
			tmp7_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
			match(ASSIGN);
			expr();
			if (0 == inputState.guessing)
			{
				e_AST = (antlr.stringtemplate.language.StringTemplateAST)returnAST;
			}
			if (0==inputState.guessing)
			{
				opts["separator"]=e_AST;
			}
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_0_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = optionList_AST;
		return opts;
		ASTPair.PutInstance(currentAST);
	}
	
	public void ifCondition() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST ifCondition_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LPAREN:
			case ID:
			case LITERAL_first:
			case LITERAL_rest:
			case LITERAL_last:
			case LITERAL_super:
			case ANONYMOUS_TEMPLATE:
			case STRING:
			case INT:
			case LBRACK:
			{
				ifAtom();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				ifCondition_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			case NOT:
			{
				antlr.stringtemplate.language.StringTemplateAST tmp8_AST = null;
				tmp8_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
				astFactory.makeASTRoot(currentAST, (AST)tmp8_AST);
				match(NOT);
				ifAtom();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				ifCondition_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_5_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = ifCondition_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void expr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST expr_AST = null;
		
		try {      // for error handling
			primaryExpr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==PLUS))
					{
						antlr.stringtemplate.language.StringTemplateAST tmp9_AST = null;
						tmp9_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
						astFactory.makeASTRoot(currentAST, (AST)tmp9_AST);
						match(PLUS);
						primaryExpr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop18_breakloop;
					}
					
				}
_loop18_breakloop:				;
			}    // ( ... )*
			expr_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_6_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = expr_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void parallelArrayTemplateApplication() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST parallelArrayTemplateApplication_AST = null;
		IToken  c = null;
		antlr.stringtemplate.language.StringTemplateAST c_AST = null;
		
		try {      // for error handling
			expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(currentAST, (AST)returnAST);
			}
			{ // ( ... )+
				int _cnt13=0;
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						match(COMMA);
						expr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(currentAST, (AST)returnAST);
						}
					}
					else
					{
						if (_cnt13 >= 1) { goto _loop13_breakloop; } else { throw new NoViableAltException(LT(1), getFilename());; }
					}
					
					_cnt13++;
				}
_loop13_breakloop:				;
			}    // ( ... )+
			c = LT(1);
			c_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(c);
			astFactory.addASTChild(currentAST, (AST)c_AST);
			match(COLON);
			anonymousTemplate();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(currentAST, (AST)returnAST);
			}
			if (0==inputState.guessing)
			{
				parallelArrayTemplateApplication_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				parallelArrayTemplateApplication_AST =
					(antlr.stringtemplate.language.StringTemplateAST) astFactory.make((AST)(antlr.stringtemplate.language.StringTemplateAST) astFactory.create(MULTI_APPLY,"MULTI_APPLY"), (AST)parallelArrayTemplateApplication_AST);
				currentAST.root = parallelArrayTemplateApplication_AST;
				if ( (null != parallelArrayTemplateApplication_AST) && (null != parallelArrayTemplateApplication_AST.getFirstChild()) )
					currentAST.child = parallelArrayTemplateApplication_AST.getFirstChild();
				else
					currentAST.child = parallelArrayTemplateApplication_AST;
				currentAST.advanceChildToEnd();
			}
			parallelArrayTemplateApplication_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_4_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = parallelArrayTemplateApplication_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void template() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST template_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LPAREN:
				case ID:
				case LITERAL_super:
				{
					namedTemplate();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(currentAST, (AST)returnAST);
					}
					break;
				}
				case ANONYMOUS_TEMPLATE:
				{
					anonymousTemplate();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(currentAST, (AST)returnAST);
					}
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			if (0==inputState.guessing)
			{
				template_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				template_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.make((AST)(antlr.stringtemplate.language.StringTemplateAST) astFactory.create(TEMPLATE), (AST)template_AST);
				currentAST.root = template_AST;
				if ( (null != template_AST) && (null != template_AST.getFirstChild()) )
					currentAST.child = template_AST.getFirstChild();
				else
					currentAST.child = template_AST;
				currentAST.advanceChildToEnd();
			}
			template_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_7_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = template_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void anonymousTemplate() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST anonymousTemplate_AST = null;
		IToken  t = null;
		antlr.stringtemplate.language.StringTemplateAST t_AST = null;
		
		try {      // for error handling
			t = LT(1);
			t_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(t);
			astFactory.addASTChild(currentAST, (AST)t_AST);
			match(ANONYMOUS_TEMPLATE);
			if (0==inputState.guessing)
			{
				
				StringTemplate anonymous = new StringTemplate();
				anonymous.setGroup(self.getGroup());
				anonymous.setEnclosingInstance(self);
				anonymous.setTemplate(t.getText());
				anonymous.defineFormalArguments(((StringTemplateToken)t).args);
				t_AST.setStringTemplate(anonymous);
				
			}
			anonymousTemplate_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_7_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = anonymousTemplate_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void ifAtom() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST ifAtom_AST = null;
		
		try {      // for error handling
			expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(currentAST, (AST)returnAST);
			}
			ifAtom_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_5_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = ifAtom_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void primaryExpr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST primaryExpr_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case LITERAL_first:
			case LITERAL_rest:
			case LITERAL_last:
			{
				function();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				primaryExpr_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			case LBRACK:
			{
				list();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				primaryExpr_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			default:
				if ((tokenSet_8_.member(LA(1))) && (tokenSet_9_.member(LA(2))))
				{
					atom();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(currentAST, (AST)returnAST);
					}
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==DOT))
							{
								antlr.stringtemplate.language.StringTemplateAST tmp11_AST = null;
								tmp11_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
								astFactory.makeASTRoot(currentAST, (AST)tmp11_AST);
								match(DOT);
								{
									switch ( LA(1) )
									{
									case ID:
									{
										antlr.stringtemplate.language.StringTemplateAST tmp12_AST = null;
										tmp12_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
										astFactory.addASTChild(currentAST, (AST)tmp12_AST);
										match(ID);
										break;
									}
									case LPAREN:
									{
										valueExpr();
										if (0 == inputState.guessing)
										{
											astFactory.addASTChild(currentAST, (AST)returnAST);
										}
										break;
									}
									default:
									{
										throw new NoViableAltException(LT(1), getFilename());
									}
									 }
								}
							}
							else
							{
								goto _loop22_breakloop;
							}
							
						}
_loop22_breakloop:						;
					}    // ( ... )*
					primaryExpr_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				}
				else {
					bool synPredMatched24 = false;
					if (((LA(1)==LPAREN||LA(1)==ID||LA(1)==LITERAL_super) && (tokenSet_10_.member(LA(2)))))
					{
						int _m24 = mark();
						synPredMatched24 = true;
						inputState.guessing++;
						try {
							{
								templateInclude();
							}
						}
						catch (RecognitionException)
						{
							synPredMatched24 = false;
						}
						rewind(_m24);
						inputState.guessing--;
					}
					if ( synPredMatched24 )
					{
						templateInclude();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(currentAST, (AST)returnAST);
						}
						primaryExpr_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
					}
					else if ((LA(1)==LPAREN) && (tokenSet_1_.member(LA(2)))) {
						valueExpr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(currentAST, (AST)returnAST);
						}
						primaryExpr_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
					}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				}break; }
			}
			catch (RecognitionException ex)
			{
				if (0 == inputState.guessing)
				{
					reportError(ex);
					recover(ex,tokenSet_11_);
				}
				else
				{
					throw ex;
				}
			}
			returnAST = primaryExpr_AST;
			ASTPair.PutInstance(currentAST);
		}
		
	public void atom() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST atom_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case ID:
			{
				antlr.stringtemplate.language.StringTemplateAST tmp13_AST = null;
				tmp13_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
				astFactory.addASTChild(currentAST, (AST)tmp13_AST);
				match(ID);
				atom_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			case STRING:
			{
				antlr.stringtemplate.language.StringTemplateAST tmp14_AST = null;
				tmp14_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
				astFactory.addASTChild(currentAST, (AST)tmp14_AST);
				match(STRING);
				atom_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			case INT:
			{
				antlr.stringtemplate.language.StringTemplateAST tmp15_AST = null;
				tmp15_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
				astFactory.addASTChild(currentAST, (AST)tmp15_AST);
				match(INT);
				atom_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			case ANONYMOUS_TEMPLATE:
			{
				antlr.stringtemplate.language.StringTemplateAST tmp16_AST = null;
				tmp16_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
				astFactory.addASTChild(currentAST, (AST)tmp16_AST);
				match(ANONYMOUS_TEMPLATE);
				atom_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_9_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = atom_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void valueExpr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST valueExpr_AST = null;
		IToken  eval = null;
		antlr.stringtemplate.language.StringTemplateAST eval_AST = null;
		
		try {      // for error handling
			eval = LT(1);
			eval_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(eval);
			astFactory.makeASTRoot(currentAST, (AST)eval_AST);
			match(LPAREN);
			templatesExpr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(currentAST, (AST)returnAST);
			}
			match(RPAREN);
			if (0==inputState.guessing)
			{
				eval_AST.setType(VALUE); eval_AST.setText("value");
			}
			valueExpr_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_9_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = valueExpr_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void templateInclude() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST templateInclude_AST = null;
		IToken  qid = null;
		antlr.stringtemplate.language.StringTemplateAST qid_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case ID:
				{
					antlr.stringtemplate.language.StringTemplateAST tmp18_AST = null;
					tmp18_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
					astFactory.addASTChild(currentAST, (AST)tmp18_AST);
					match(ID);
					argList();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(currentAST, (AST)returnAST);
					}
					break;
				}
				case LITERAL_super:
				{
					match(LITERAL_super);
					match(DOT);
					qid = LT(1);
					qid_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(qid);
					astFactory.addASTChild(currentAST, (AST)qid_AST);
					match(ID);
					if (0==inputState.guessing)
					{
						qid_AST.setText("super."+qid_AST.getText());
					}
					argList();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(currentAST, (AST)returnAST);
					}
					break;
				}
				case LPAREN:
				{
					indirectTemplate();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(currentAST, (AST)returnAST);
					}
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			if (0==inputState.guessing)
			{
				templateInclude_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				templateInclude_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.make((AST)(antlr.stringtemplate.language.StringTemplateAST) astFactory.create(INCLUDE,"include"), (AST)templateInclude_AST);
				currentAST.root = templateInclude_AST;
				if ( (null != templateInclude_AST) && (null != templateInclude_AST.getFirstChild()) )
					currentAST.child = templateInclude_AST.getFirstChild();
				else
					currentAST.child = templateInclude_AST;
				currentAST.advanceChildToEnd();
			}
			templateInclude_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_11_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = templateInclude_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void function() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST function_AST = null;
		
		try {      // for error handling
			{
				switch ( LA(1) )
				{
				case LITERAL_first:
				{
					antlr.stringtemplate.language.StringTemplateAST tmp21_AST = null;
					tmp21_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
					astFactory.addASTChild(currentAST, (AST)tmp21_AST);
					match(LITERAL_first);
					break;
				}
				case LITERAL_rest:
				{
					antlr.stringtemplate.language.StringTemplateAST tmp22_AST = null;
					tmp22_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
					astFactory.addASTChild(currentAST, (AST)tmp22_AST);
					match(LITERAL_rest);
					break;
				}
				case LITERAL_last:
				{
					antlr.stringtemplate.language.StringTemplateAST tmp23_AST = null;
					tmp23_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
					astFactory.addASTChild(currentAST, (AST)tmp23_AST);
					match(LITERAL_last);
					break;
				}
				default:
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				 }
			}
			singleArg();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(currentAST, (AST)returnAST);
			}
			if (0==inputState.guessing)
			{
				function_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				function_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.make((AST)(antlr.stringtemplate.language.StringTemplateAST) astFactory.create(FUNCTION), (AST)function_AST);
				currentAST.root = function_AST;
				if ( (null != function_AST) && (null != function_AST.getFirstChild()) )
					currentAST.child = function_AST.getFirstChild();
				else
					currentAST.child = function_AST;
				currentAST.advanceChildToEnd();
			}
			function_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_11_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = function_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void list() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST list_AST = null;
		IToken  lb = null;
		antlr.stringtemplate.language.StringTemplateAST lb_AST = null;
		
		try {      // for error handling
			lb = LT(1);
			lb_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(lb);
			astFactory.makeASTRoot(currentAST, (AST)lb_AST);
			match(LBRACK);
			if (0==inputState.guessing)
			{
				lb_AST.setType(LIST); lb_AST.setText("value");
			}
			expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COMMA))
					{
						match(COMMA);
						expr();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop38_breakloop;
					}
					
				}
_loop38_breakloop:				;
			}    // ( ... )*
			match(RBRACK);
			list_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_11_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = list_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void nonAlternatingTemplateExpr() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST nonAlternatingTemplateExpr_AST = null;
		IToken  c = null;
		antlr.stringtemplate.language.StringTemplateAST c_AST = null;
		
		try {      // for error handling
			expr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(currentAST, (AST)returnAST);
			}
			{    // ( ... )*
				for (;;)
				{
					if ((LA(1)==COLON))
					{
						c = LT(1);
						c_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(c);
						astFactory.makeASTRoot(currentAST, (AST)c_AST);
						match(COLON);
						if (0==inputState.guessing)
						{
							c_AST.setType(APPLY);
						}
						template();
						if (0 == inputState.guessing)
						{
							astFactory.addASTChild(currentAST, (AST)returnAST);
						}
					}
					else
					{
						goto _loop28_breakloop;
					}
					
				}
_loop28_breakloop:				;
			}    // ( ... )*
			nonAlternatingTemplateExpr_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_12_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = nonAlternatingTemplateExpr_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void singleArg() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST singleArg_AST = null;
		
		try {      // for error handling
			match(LPAREN);
			nonAlternatingTemplateExpr();
			if (0 == inputState.guessing)
			{
				astFactory.addASTChild(currentAST, (AST)returnAST);
			}
			match(RPAREN);
			if (0==inputState.guessing)
			{
				singleArg_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				singleArg_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.make((AST)(antlr.stringtemplate.language.StringTemplateAST) astFactory.create(SINGLEVALUEARG,"SINGLEVALUEARG"), (AST)singleArg_AST);
				currentAST.root = singleArg_AST;
				if ( (null != singleArg_AST) && (null != singleArg_AST.getFirstChild()) )
					currentAST.child = singleArg_AST.getFirstChild();
				else
					currentAST.child = singleArg_AST;
				currentAST.advanceChildToEnd();
			}
			singleArg_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_11_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = singleArg_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void namedTemplate() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST namedTemplate_AST = null;
		IToken  qid = null;
		antlr.stringtemplate.language.StringTemplateAST qid_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case ID:
			{
				antlr.stringtemplate.language.StringTemplateAST tmp28_AST = null;
				tmp28_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
				astFactory.addASTChild(currentAST, (AST)tmp28_AST);
				match(ID);
				argList();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				namedTemplate_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			case LITERAL_super:
			{
				match(LITERAL_super);
				match(DOT);
				qid = LT(1);
				qid_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(qid);
				astFactory.addASTChild(currentAST, (AST)qid_AST);
				match(ID);
				if (0==inputState.guessing)
				{
					qid_AST.setText("super."+qid_AST.getText());
				}
				argList();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				namedTemplate_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			case LPAREN:
			{
				indirectTemplate();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				namedTemplate_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_7_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = namedTemplate_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void argList() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST argList_AST = null;
		
		try {      // for error handling
			if ((LA(1)==LPAREN) && (LA(2)==RPAREN))
			{
				match(LPAREN);
				match(RPAREN);
				if (0==inputState.guessing)
				{
					argList_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
					argList_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(ARGS,"ARGS");
					currentAST.root = argList_AST;
					if ( (null != argList_AST) && (null != argList_AST.getFirstChild()) )
						currentAST.child = argList_AST.getFirstChild();
					else
						currentAST.child = argList_AST;
					currentAST.advanceChildToEnd();
				}
			}
			else {
				bool synPredMatched44 = false;
				if (((LA(1)==LPAREN) && (tokenSet_1_.member(LA(2)))))
				{
					int _m44 = mark();
					synPredMatched44 = true;
					inputState.guessing++;
					try {
						{
							singleArg();
						}
					}
					catch (RecognitionException)
					{
						synPredMatched44 = false;
					}
					rewind(_m44);
					inputState.guessing--;
				}
				if ( synPredMatched44 )
				{
					singleArg();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(currentAST, (AST)returnAST);
					}
					argList_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				}
				else if ((LA(1)==LPAREN) && (LA(2)==ID||LA(2)==DOTDOTDOT)) {
					match(LPAREN);
					argumentAssignment();
					if (0 == inputState.guessing)
					{
						astFactory.addASTChild(currentAST, (AST)returnAST);
					}
					{    // ( ... )*
						for (;;)
						{
							if ((LA(1)==COMMA))
							{
								match(COMMA);
								argumentAssignment();
								if (0 == inputState.guessing)
								{
									astFactory.addASTChild(currentAST, (AST)returnAST);
								}
							}
							else
							{
								goto _loop46_breakloop;
							}
							
						}
_loop46_breakloop:						;
					}    // ( ... )*
					match(RPAREN);
					if (0==inputState.guessing)
					{
						argList_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
						argList_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.make((AST)(antlr.stringtemplate.language.StringTemplateAST) astFactory.create(ARGS,"ARGS"), (AST)argList_AST);
						currentAST.root = argList_AST;
						if ( (null != argList_AST) && (null != argList_AST.getFirstChild()) )
							currentAST.child = argList_AST.getFirstChild();
						else
							currentAST.child = argList_AST;
						currentAST.advanceChildToEnd();
					}
					argList_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				}
				else
				{
					throw new NoViableAltException(LT(1), getFilename());
				}
				}
			}
			catch (RecognitionException ex)
			{
				if (0 == inputState.guessing)
				{
					reportError(ex);
					recover(ex,tokenSet_11_);
				}
				else
				{
					throw ex;
				}
			}
			returnAST = argList_AST;
			ASTPair.PutInstance(currentAST);
		}
		
/** Match (foo)() and (foo+".terse")() */
	public void indirectTemplate() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST indirectTemplate_AST = null;
		antlr.stringtemplate.language.StringTemplateAST e_AST = null;
		antlr.stringtemplate.language.StringTemplateAST args_AST = null;
		
		try {      // for error handling
			antlr.stringtemplate.language.StringTemplateAST tmp36_AST = null;
			tmp36_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
			match(LPAREN);
			expr();
			if (0 == inputState.guessing)
			{
				e_AST = (antlr.stringtemplate.language.StringTemplateAST)returnAST;
			}
			antlr.stringtemplate.language.StringTemplateAST tmp37_AST = null;
			tmp37_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
			match(RPAREN);
			argList();
			if (0 == inputState.guessing)
			{
				args_AST = (antlr.stringtemplate.language.StringTemplateAST)returnAST;
			}
			if (0==inputState.guessing)
			{
				indirectTemplate_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				indirectTemplate_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.make((AST)(antlr.stringtemplate.language.StringTemplateAST) astFactory.create(VALUE,"value"), (AST)e_AST, (AST)args_AST);
				currentAST.root = indirectTemplate_AST;
				if ( (null != indirectTemplate_AST) && (null != indirectTemplate_AST.getFirstChild()) )
					currentAST.child = indirectTemplate_AST.getFirstChild();
				else
					currentAST.child = indirectTemplate_AST;
				currentAST.advanceChildToEnd();
			}
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_11_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = indirectTemplate_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public void argumentAssignment() //throws RecognitionException, TokenStreamException
{
		
		returnAST = null;
		ASTPair currentAST = ASTPair.GetInstance();
		antlr.stringtemplate.language.StringTemplateAST argumentAssignment_AST = null;
		
		try {      // for error handling
			switch ( LA(1) )
			{
			case ID:
			{
				antlr.stringtemplate.language.StringTemplateAST tmp38_AST = null;
				tmp38_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
				astFactory.addASTChild(currentAST, (AST)tmp38_AST);
				match(ID);
				antlr.stringtemplate.language.StringTemplateAST tmp39_AST = null;
				tmp39_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
				astFactory.makeASTRoot(currentAST, (AST)tmp39_AST);
				match(ASSIGN);
				nonAlternatingTemplateExpr();
				if (0 == inputState.guessing)
				{
					astFactory.addASTChild(currentAST, (AST)returnAST);
				}
				argumentAssignment_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			case DOTDOTDOT:
			{
				antlr.stringtemplate.language.StringTemplateAST tmp40_AST = null;
				tmp40_AST = (antlr.stringtemplate.language.StringTemplateAST) astFactory.create(LT(1));
				astFactory.addASTChild(currentAST, (AST)tmp40_AST);
				match(DOTDOTDOT);
				argumentAssignment_AST = (antlr.stringtemplate.language.StringTemplateAST)currentAST.root;
				break;
			}
			default:
			{
				throw new NoViableAltException(LT(1), getFilename());
			}
			 }
		}
		catch (RecognitionException ex)
		{
			if (0 == inputState.guessing)
			{
				reportError(ex);
				recover(ex,tokenSet_12_);
			}
			else
			{
				throw ex;
			}
		}
		returnAST = argumentAssignment_AST;
		ASTPair.PutInstance(currentAST);
	}
	
	public new antlr.stringtemplate.language.StringTemplateAST getAST()
	{
		return (antlr.stringtemplate.language.StringTemplateAST) returnAST;
	}
	
	private void initializeFactory()
	{
		if (astFactory == null)
		{
			astFactory = new ASTFactory("antlr.stringtemplate.language.StringTemplateAST");
		}
		initializeASTFactory( astFactory );
	}
	static public void initializeASTFactory( ASTFactory factory )
	{
		factory.setMaxNodeType(39);
	}
	
	public static readonly string[] tokenNames_ = new string[] {
		@"""<0>""",
		@"""EOF""",
		@"""<2>""",
		@"""NULL_TREE_LOOKAHEAD""",
		@"""APPLY""",
		@"""MULTI_APPLY""",
		@"""ARGS""",
		@"""INCLUDE""",
		@"""if""",
		@"""VALUE""",
		@"""TEMPLATE""",
		@"""FUNCTION""",
		@"""SINGLEVALUEARG""",
		@"""LIST""",
		@"""SEMI""",
		@"""LPAREN""",
		@"""RPAREN""",
		@"""separator""",
		@"""ASSIGN""",
		@"""COLON""",
		@"""COMMA""",
		@"""NOT""",
		@"""PLUS""",
		@"""DOT""",
		@"""ID""",
		@"""first""",
		@"""rest""",
		@"""last""",
		@"""super""",
		@"""ANONYMOUS_TEMPLATE""",
		@"""STRING""",
		@"""INT""",
		@"""LBRACK""",
		@"""RBRACK""",
		@"""DOTDOTDOT""",
		@"""TEMPLATE_ARGS""",
		@"""NESTED_ANONYMOUS_TEMPLATE""",
		@"""ESC_CHAR""",
		@"""WS""",
		@"""WS_CHAR"""
	};
	
	private static long[] mk_tokenSet_0_()
	{
		long[] data = { 2L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_0_ = new BitSet(mk_tokenSet_0_());
	private static long[] mk_tokenSet_1_()
	{
		long[] data = { 8573190144L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_1_ = new BitSet(mk_tokenSet_1_());
	private static long[] mk_tokenSet_2_()
	{
		long[] data = { 8586821632L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_2_ = new BitSet(mk_tokenSet_2_());
	private static long[] mk_tokenSet_3_()
	{
		long[] data = { 8586379266L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_3_ = new BitSet(mk_tokenSet_3_());
	private static long[] mk_tokenSet_4_()
	{
		long[] data = { 81922L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_4_ = new BitSet(mk_tokenSet_4_());
	private static long[] mk_tokenSet_5_()
	{
		long[] data = { 65536L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_5_ = new BitSet(mk_tokenSet_5_());
	private static long[] mk_tokenSet_6_()
	{
		long[] data = { 8591589378L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_6_ = new BitSet(mk_tokenSet_6_());
	private static long[] mk_tokenSet_7_()
	{
		long[] data = { 1654786L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_7_ = new BitSet(mk_tokenSet_7_());
	private static long[] mk_tokenSet_8_()
	{
		long[] data = { 3774873600L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_8_ = new BitSet(mk_tokenSet_8_());
	private static long[] mk_tokenSet_9_()
	{
		long[] data = { 8604172290L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_9_ = new BitSet(mk_tokenSet_9_());
	private static long[] mk_tokenSet_10_()
	{
		long[] data = { 8581578752L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_10_ = new BitSet(mk_tokenSet_10_());
	private static long[] mk_tokenSet_11_()
	{
		long[] data = { 8595783682L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_11_ = new BitSet(mk_tokenSet_11_());
	private static long[] mk_tokenSet_12_()
	{
		long[] data = { 1114112L, 0L};
		return data;
	}
	public static readonly BitSet tokenSet_12_ = new BitSet(mk_tokenSet_12_());
	
}
}
