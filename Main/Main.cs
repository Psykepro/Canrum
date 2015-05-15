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
            List<string> code = new List<string>();
            code.Add(Console.ReadLine());
            while (code.Last() != "compile")
            {
                code.Add(Console.ReadLine());
            }
            code.RemoveAt(code.Count-1);
            CodeManager.CompileAndRun(String.Join("", code.ToArray()), "test.exe", "Boss Nakov");   
        }

        
    }
}
