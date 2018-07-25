using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileService {
  public class CompilerService {
    public Output Compile( string codeString ) {
      var output = new Output();
      var codeProvider = CodeDomProvider.CreateProvider( "CSharp" );
      var outputExePath = $"Output_{Guid.NewGuid()}.exe";

      var parameters = new CompilerParameters {
        GenerateExecutable = true,
        OutputAssembly = outputExePath
      };
      var results = codeProvider.CompileAssemblyFromSource( parameters, codeString );

      if ( results.Errors.Count > 0 ) {
        var errorsString = new StringBuilder();
        foreach ( CompilerError compErr in results.Errors ) {
          errorsString.AppendLine( $"Line number {compErr.Line}, Error Number: {compErr.ErrorNumber} ,  {compErr.ErrorText}" );

        }
        output.Success = false;
        output.Result = errorsString.ToString();
        return output;
      }
      output.Success = true;
      output.Result = new ConsoleOutputReader().ReadOutputFromProcess( outputExePath );
      return output;
    }
  }
}
