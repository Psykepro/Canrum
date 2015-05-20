using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace Main
{
    public static class CodeManager
    {
        public static void StartCodeCompiler(string[] libraries)
        {
            List<string> code = new List<string>();

            string endCode = "compile";
            Console.WriteLine("When you're done with the program, type {0} on the last line.", endCode);

            string line = Console.ReadLine();

            while (line != endCode)
            {
                code.Add(line);
                line = Console.ReadLine();
            }

            CompileAndRun(code, "Boss Nakov", libraries);
        }

        private static bool CompileAndRun(List<string> sourceFile, string parameters, string[] libraries)
        {
            bool result = CompileCode(sourceFile, "program.exe", libraries);
            if (result) Process.Start("program.exe", parameters);
            return result;
        }

        private static bool CompileCode(List<string> sourceFile, String exeFile, string[] libraries)
        {
            CodeDomProvider provider = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            List<string> codeLines = new List<string>();
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
                cp.MainClass = "ProblemNamespace.ProblemClass";
            }
            if(libraries != null)
                codeLines.AddRange(libraries.Select(l => "using "+l+";"));
            codeLines.AddRange(new[]
            {
                "using System;\n",
                "namespace ProblemNamespace\n",
                "{\n",
                "class ProblemClass\n",
                "{\n",
                "static void Main(string[] args)\n",
                "{\n"
            });
            codeLines.AddRange(sourceFile);
            codeLines.AddRange(new[]
            {
                "Console.ReadKey();\n",
                "}\n",
                "}\n",
                "}\n"
            });

            string finalCode = String.Join("", codeLines);
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, finalCode);

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
                    cp.TempFiles.Count);
            }

            return cr.Errors.Count <= 0;
        }
    }
}
