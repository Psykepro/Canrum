﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace Canrum
{
    public class CodeManager
    {
        public static bool CompileAndRun(String sourceFile, String exeFile, String parameters)
        {
            bool result = CompileCode(sourceFile, exeFile);
            if (result) Process.Start(exeFile, parameters);
            return result;
        }

        private static bool CompileCode(String sourceFile, String exeFile)
        {
            CodeDomProvider provider = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();

            cp.GenerateExecutable = true;
            cp.OutputAssembly = exeFile;
            cp.IncludeDebugInformation = false;

            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.core.dll");

            cp.GenerateInMemory = false;
            cp.WarningLevel = 3;
            cp.TreatWarningsAsErrors = false;
            cp.CompilerOptions = "/optimize";

            cp.TempFiles = new TempFileCollection(".", false);

            if (provider.Supports(GeneratorSupport.EntryPointMethod))
            {
                cp.MainClass = "Main2.Main1";
            }
            sourceFile = "using System;\n" +
                         "using System.Collections.Generic;\n" +
                         "using System.Text;\n" +
                         "using System.Linq;\n" +
                         "using System.Threading.Tasks;\n" +
                         "namespace Main2\n" +
                         "{\n" +
                         "class Main1\n" +
                         "{\n" +
                         "static void Main(string[] args)\n" +
                         "{\n" +
                         sourceFile +
                         "Console.ReadKey();\n"+
                         "}\n" +
                         "}\n" +
                         "}\n";
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceFile);

            if (cr.Errors.Count > 0)
            {
                Console.WriteLine("Errors building {0} into {1}",
                    sourceFile, cr.PathToAssembly);
                foreach (CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Source {0} built into {1} successfully.",
                    sourceFile, cr.PathToAssembly);
                Console.WriteLine("{0} temporary files created during the compilation.",
                    cp.TempFiles.Count.ToString());
            }

            return cr.Errors.Count <= 0;
        }
    }
}
