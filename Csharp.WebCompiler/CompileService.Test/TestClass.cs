using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileService.Test {
  public class TestClass {
    public static void Main( string[] args )
    {
      string code = "using System; namespace ashok{ public class MyClass{ public static void Main(string[] args){ Console.WriteLine(\"Hola...Working :D\"); } } }";
      var compileService = new CompilerService();
      var result = compileService.Compile(code);
      Console.WriteLine(result.Success);
      Console.WriteLine(result.Result);
      Console.ReadKey();
    }
  }
}
