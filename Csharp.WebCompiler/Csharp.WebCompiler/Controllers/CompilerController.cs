using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CompileService;
using Csharp.WebCompiler.Models;

namespace Csharp.WebCompiler.Controllers
{
    public class CompilerController : ApiController
    {
      [Route("api/compiler/compile")]
      [HttpPost]
      public Output Compile([FromBody]CompileInput compileInput)
      {
        return new CompilerService().Compile(compileInput.Code);
      }
  }
}
