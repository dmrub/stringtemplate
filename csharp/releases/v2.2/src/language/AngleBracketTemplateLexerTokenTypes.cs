// $ANTLR 2.7.5 (20050128): "angle.bracket.template.g" -> "AngleBracketTemplateLexer.cs"$

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
using System.IO;

namespace antlr.stringtemplate.language
{
	public class AngleBracketTemplateLexerTokenTypes
	{
		public const int EOF = 1;
		public const int NULL_TREE_LOOKAHEAD = 3;
		public const int LITERAL = 4;
		public const int NEWLINE = 5;
		public const int ACTION = 6;
		public const int IF = 7;
		public const int ELSE = 8;
		public const int ENDIF = 9;
		public const int EXPR = 10;
		public const int TEMPLATE = 11;
		public const int IF_EXPR = 12;
		public const int ESC = 13;
		public const int SUBTEMPLATE = 14;
		public const int NESTED_PARENS = 15;
		public const int INDENT = 16;
		public const int COMMENT = 17;
		
	}
}
