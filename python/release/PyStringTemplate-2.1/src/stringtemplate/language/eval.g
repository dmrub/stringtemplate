header {
import stringtemplate

from cStringIO import StringIO

class NameValuePair(object):

    def __init__(self):
        self.name = None
        self.value = None

}

header "ActionEvaluator.__init__" {
    self.this = None
    self.out = None
    self.chunk = None
}

options {
    language = "Python";
}

class ActionEvaluator extends TreeParser;

options {
    importVocab=ActionParser;
    ASTLabelType = "stringtemplate.language.StringTemplateAST";
}

{
    def initialize(self, this, chunk, out):
        self.this = this
        self.chunk = chunk
        self.out = out

    def reportError(self, e):
        self.this.error("template parse error", e)
}

action returns [numCharsWritten = 0]
{
    e = None
}
    :   e = expr
        {
          numCharsWritten = self.chunk.writeAttribute(self.this,e,self.out)
        }
    ;

expr returns [value]
{
    a = None
    b = None
    e = None
}
    :   #(PLUS a=expr b=expr {value = self.chunk.add(a,b)})
    |   value=templateApplication
    |   value=attribute
    |   value=templateInclude
    |   #(VALUE e=expr)
        // convert to string (force early eval)
        {
            buf = StringIO()
            writerClass = self.out.__class__
            sw = None
            try:
                sw = writerClass(buf)
            except Exception, exc:
                // default stringtemplate.AutoIndentWriter
                self.this.error("eval: cannot make implementation of " +
                                "StringTemplateWriter", exc)
                sw = stringtemplate.AutoIndentWriter(buf)
            self.chunk.writeAttribute(self.this, e, sw)
            value = buf.getvalue()
            buf.close()
        }
    ;

templateInclude returns [value = None]
{
    args = None
    name = ""
    n = None
}
    :   #( INCLUDE
            (   id:ID a1:.
                { name=id.getText(); args=#a1 }
            |   #( VALUE n=expr a2:. )
                {if n: name = str(n); args=#a2 }
            )
         )
        {
            if name:
                value = self.chunk.getTemplateInclude(self.this, name, args)
        }
    ;

/** Apply template(s) to an attribute; can be applied to another apply
 *  result.
 */
templateApplication returns [value = None]
{
    a = None
    templatesToApply = []
}
    :   #(  APPLY a=expr (template[templatesToApply])+
            {value = self.chunk.applyListOfAlternatingTemplates(self.this,a,templatesToApply)}
         )
    ;

template[templatesToApply]
{
    argumentContext = {}
    n = None
}
    :   #(  TEMPLATE
            (   t:ID args:. // don't eval argList now; must re-eval each iteration
                {
                    templateName = t.getText()
                    group = self.this.getGroup()
                    embedded = group.getEmbeddedInstanceOf(self.this, templateName)
                    if embedded:
                        embedded.setArgumentsAST(#args)
                        templatesToApply.append(embedded)
                }

            |   anon:ANONYMOUS_TEMPLATE
                {
                    anonymous = anon.getStringTemplate()
                    templatesToApply.append(anonymous)
                }

            |   #( VALUE n=expr argumentContext=argList[None] )
                {
                    if n:
                        templateName = str(n)
                        group = self.this.getGroup()
                        embedded = group.getEmbeddedInstanceOf(self.this, templateName)
                        if embedded:
                            embedded.setArgumentsAST(#args)
                            templatesToApply.append(embedded)
                }
            )
         )
    ;

ifCondition returns [value = False]
{
    a = None
}
    :   a=ifAtom {value = self.chunk.testAttributeTrue(a)}
    |   #(NOT a=ifAtom) {value = not self.chunk.testAttributeTrue(a)}
        ;

ifAtom returns [value = None]
    :   value=expr
    ;

attribute returns [value = None]
{
    obj = None
}
    :   #( DOT obj=attribute prop:ID )
        { value = self.chunk.getObjectProperty(self.this,obj,prop.getText()) }

    |   i3:ID
        {
            try:
                value=self.this.getAttribute(i3.getText())
            except KeyError, nse:
                // rethrow with more precise error message
                raise KeyError(str(nse) + " in template " +
                               self.this.getName())
        }

    |   i:INT { value = int(i.getText()) }

    |   s:STRING { value = s.getText() }
    ;

argList[initialContext]
    returns [argumentContext]
{
    argumentContext = initialContext
    if not argumentContext:
        argumentContext = {}
}
    :   #( ARGS (argumentAssignment[argumentContext])* )
    ;

argumentAssignment[argumentContext]
{
    e = None
}
    :   #( ASSIGN arg:ID e=expr
           {
             if e:
                 self.this.rawSetAttribute(argumentContext,arg.getText(), e)
           }
        )
    ;

