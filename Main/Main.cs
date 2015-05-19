using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace Main
{
    static class Canrum
    {
        static void Main(string[] args)
        {
            if(Reader.ReadFile("test.cs"))
                CodeManager.StartCodeCompiler();
        }

        
    }
}
