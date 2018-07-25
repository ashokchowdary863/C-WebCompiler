using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileService {
  public class ConsoleOutputReader {

    public string ReadOutputFromProcess(string exePath)
    {
      var outputString=new StringBuilder();
      var process = new Process {
        StartInfo = new ProcessStartInfo {
          FileName = exePath,
          UseShellExecute = false,
          RedirectStandardOutput = true,
          CreateNoWindow = true
        }
      };
      process.Start();
      while ( !process.StandardOutput.EndOfStream ) {
         outputString.AppendLine(process.StandardOutput.ReadLine());
      }

      process.WaitForExit();
      File.Delete(exePath);
      return outputString.ToString();
    }
  }
}
