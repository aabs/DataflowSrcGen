﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace ActorSrcGen.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using ActorSrcGen.Helpers;
    using ActorSrcGen.Model;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class Actor : ActorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 8 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

var input = ActorNode.Symbol;
var sb = new StringBuilder();
sb.AppendHeader(input.Syntax, input.Symbol);
var className = ActorNode.Name;
var baseClass = "Dataflow";
var inputTypeName = ActorNode.InputTypes.First().RenderTypename(true);
var outputTypeName = ActorNode.OutputTypes.First().RenderTypename(true);

if (ActorNode.HasSingleInputType &&  ActorNode.HasAnyOutputTypes)
{
    baseClass = $"Dataflow<{inputTypeName}, {outputTypeName}>";
}
else
{
    baseClass = $"Dataflow<{inputTypeName}>";
}

            
            #line default
            #line hidden
            
            #line 26 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sb.ToString()));
            
            #line default
            #line hidden
            this.Write("\r\nusing System.Threading.Tasks.Dataflow;\r\nusing Gridsum.DataflowEx;\r\n\r\npublic par" +
                    "tial class ");
            
            #line 30 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 30 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(baseClass));
            
            #line default
            #line hidden
            this.Write(", IActor< ");
            
            #line 30 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(inputTypeName));
            
            #line default
            #line hidden
            this.Write(" >\r\n{\r\n\r\n\tpublic ");
            
            #line 33 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            
            #line default
            #line hidden
            this.Write("(DataflowOptions dataflowOptions = null) : base(DataflowOptions.Default)\r\n\t{\r\n");
            
            #line 35 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

foreach(var step in ActorNode.StepNodes)
{
    string blockName = ChooseBlockName(step);
    string blockTypeName = ChooseBlockType(step);


            
            #line default
            #line hidden
            this.Write("        ");
            
            #line 42 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(blockName));
            
            #line default
            #line hidden
            this.Write(" = new ");
            
            #line 42 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(blockTypeName));
            
            #line default
            #line hidden
            this.Write("(\r\n\t\t    ");
            
            #line 43 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(new HandlerBody(step).TransformText()));
            
            #line default
            #line hidden
            this.Write(",\r\n            new ExecutionDataflowBlockOptions() {\r\n                BoundedCapa" +
                    "city = 1,\r\n                MaxDegreeOfParallelism = 1\r\n        });\r\n        Regi" +
                    "sterChild(");
            
            #line 48 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(blockName));
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n");
            
            #line 50 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

}

            
            #line default
            #line hidden
            this.Write("\t}\r\n\r\n");
            
            #line 55 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

    foreach (var step in ActorNode.StepNodes)
    {
        string blockName = ChooseBlockName(step);
        string blockTypeName = ChooseBlockType(step);


            
            #line default
            #line hidden
            this.Write("        ");
            
            #line 62 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(blockTypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 62 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(blockName));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 63 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

    }

    foreach (var step in ActorNode.EntryNodes)
    {
        if (step.Method.GetAttributes().Any(a => a.AttributeClass is { Name: nameof(ReceiverAttribute) }))
        {
            var methodName = $"Receive{step.Method.Name}";
            var stepInputTypeName = step.InputTypeName;
            var postMethodName = "Call";
            if (ActorNode.HasMultipleInputTypes)
            {
                postMethodName = $"Call{step.Method.Name}";
            }

            
            #line default
            #line hidden
            this.Write("    protected partial Task< ");
            
            #line 78 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(stepInputTypeName));
            
            #line default
            #line hidden
            this.Write(" > ");
            
            #line 78 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(methodName));
            
            #line default
            #line hidden
            this.Write("(CancellationToken cancellationToken);    \r\n\r\n    public async Task ListenFor");
            
            #line 80 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(methodName));
            
            #line default
            #line hidden
            this.Write("(CancellationToken cancellationToken)\r\n    {\r\n        while (!cancellationToken.I" +
                    "sCancellationRequested)\r\n        {\r\n            ");
            
            #line 84 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(stepInputTypeName));
            
            #line default
            #line hidden
            this.Write(" incomingValue = await ");
            
            #line 84 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(methodName));
            
            #line default
            #line hidden
            this.Write("(cancellationToken);\r\n            ");
            
            #line 85 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(postMethodName));
            
            #line default
            #line hidden
            this.Write("(incomingValue);\r\n        }\r\n    }\r\n");
            
            #line 88 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

        }
    }

    // Generate IO Block Accessors
    if (ActorNode.HasSingleInputType)
    {

            
            #line default
            #line hidden
            this.Write("    public override ITargetBlock<");
            
            #line 96 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ActorNode.InputTypeNames.First()));
            
            #line default
            #line hidden
            this.Write(" > InputBlock { get => _");
            
            #line 96 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ActorNode.EntryNodes.First().Method.Name));
            
            #line default
            #line hidden
            this.Write(" ; }\r\n");
            
            #line 97 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

    }
    else
    {
        foreach (var en in ActorNode.EntryNodes)
        {

            
            #line default
            #line hidden
            this.Write("    public ITargetBlock< ");
            
            #line 104 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(en.InputTypeName));
            
            #line default
            #line hidden
            this.Write(" >  ");
            
            #line 104 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(en.Method.Name));
            
            #line default
            #line hidden
            this.Write(" InputBlock { get => _");
            
            #line 104 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(en.Method.Name));
            
            #line default
            #line hidden
            this.Write("; }\r\n");
            
            #line 105 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

        }
    }
    if (ActorNode.OutputMethods.Any())
    {
        if (ActorNode.HasSingleOutputType)
        {
            var step = ActorNode.ExitNodes.First(x => !x.Method.ReturnsVoid);
            var rt = step.Method.ReturnType.RenderTypename(true);
            var stepName = ChooseBlockName(step);

            
            #line default
            #line hidden
            this.Write("    public override ISourceBlock< ");
            
            #line 116 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(rt));
            
            #line default
            #line hidden
            this.Write(" > OutputBlock { get => ");
            
            #line 116 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(stepName));
            
            #line default
            #line hidden
            this.Write("; }\r\n");
            
            #line 117 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

        }
        else
        {
            foreach (var step in ActorNode.ExitNodes)
            {
                var rt = step.Method.ReturnType.RenderTypename(true);
        
            
            #line default
            #line hidden
            this.Write("                    public ISourceBlock<");
            
            #line 125 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(rt));
            
            #line default
            #line hidden
            this.Write(" > ");
            
            #line 125 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(step.Method.Name));
            
            #line default
            #line hidden
            this.Write(" OutputBlock { get => _");
            
            #line 125 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(step.Method.Name));
            
            #line default
            #line hidden
            this.Write(" ; }\r\n        ");
            
            #line 126 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

            }
        }
    }

    // generate post methods
    if (ActorNode.HasSingleInputType)
    {
        var inputType = ActorNode.InputTypeNames.First();

            
            #line default
            #line hidden
            this.Write("    public bool Call(");
            
            #line 136 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(inputType));
            
            #line default
            #line hidden
            this.Write(" input) => InputBlock.Post(input);\r\n    public async Task<bool> Cast(");
            
            #line 137 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(inputType));
            
            #line default
            #line hidden
            this.Write(" input) => await InputBlock.SendAsync(input);\r\n");
            
            #line 138 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

    }
    else if (ActorNode.HasMultipleInputTypes)
    {
        foreach (var step in ActorNode.EntryNodes)
        {
            var inputType = step.InputTypeName;

            
            #line default
            #line hidden
            this.Write("    public bool Call");
            
            #line 146 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(step.Method.Name));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 146 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(inputType));
            
            #line default
            #line hidden
            this.Write(" input) => ");
            
            #line 146 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(step.Method.Name));
            
            #line default
            #line hidden
            this.Write("InputBlock.Post(input);\r\n    public async Task<bool> Cast");
            
            #line 147 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(step.Method.Name));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 147 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(inputType));
            
            #line default
            #line hidden
            this.Write(" input) => await ");
            
            #line 147 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(step.Method.Name));
            
            #line default
            #line hidden
            this.Write("InputBlock.SendAsync(input);\r\n    ");
            
            #line 148 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

        }
    }

        foreach (var step in ActorNode.ExitNodes.Where(x => !x.Method.ReturnsVoid)) // non void end methods
        {
            var om = step.Method;
            var blockName = ChooseBlockName(step);
            var receiverMethodName = $"Accept{om.Name}Async".Replace("AsyncAsync", "Async");
            if (ActorNode.HasSingleOutputType)
                receiverMethodName = "AcceptAsync";

            
            #line default
            #line hidden
            this.Write("    \r\n    public async Task<");
            
            #line 161 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(outputTypeName));
            
            #line default
            #line hidden
            this.Write("> ");
            
            #line 161 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverMethodName));
            
            #line default
            #line hidden
            this.Write("(CancellationToken cancellationToken)\r\n    {\r\n        try\r\n        {\r\n           " +
                    " var result = await ");
            
            #line 165 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(blockName));
            
            #line default
            #line hidden
            this.Write(".ReceiveAsync(cancellationToken);\r\n            return result;\r\n        }\r\n       " +
                    " catch (OperationCanceledException operationCanceledException)\r\n        {\r\n     " +
                    "       return await Task.FromCanceled<");
            
            #line 170 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(om.ReturnType.RenderTypename(true)));
            
            #line default
            #line hidden
            this.Write(">(cancellationToken);\r\n        }\r\n    }\r\n");
            
            #line 173 "C:\dev\aabs\ActorSrcGen\ActorSrcGen\Templates\Actor.tt"

        }


            
            #line default
            #line hidden
            this.Write("}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public class ActorBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        public System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
