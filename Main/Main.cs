using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace Canrum
{
    static class Canrum
    {
        static void Main(string[] args)
        {
            
        }

        static void CodeCompiler()
        {
            List<string> code = new List<string>();
            string line = Console.ReadLine();

            while (line != "compile")
            {
                if (Console.KeyAvailable)
                    code.Add(Console.ReadLine());
                line = Console.ReadLine();
            }

            CodeManager.CompileAndRun(code, "Boss Nakov");
        }
        
    }
}
